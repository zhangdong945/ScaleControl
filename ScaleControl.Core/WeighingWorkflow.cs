using System;
using System.Collections.Generic;
using System.Linq;
using ScaleControl.Models.Entities;
using ScaleControl.Models.Enums;
using ScaleControl.Models.Interfaces;

namespace ScaleControl.Core
{
    /// <summary>
    /// 称重工作流引擎 — 协调硬件读取、数据存取、计算、防作弊校验和磅单号生成
    /// </summary>
    public class WeighingWorkflow : IWeighingWorkflow
    {
        private readonly IWeighingRepository _repository;
        private readonly IScaleDriver _scaleDriver;
        private readonly AntiCheatChecker _antiCheatChecker;
        private readonly TicketNumberGenerator _ticketGenerator;

        public WeighingMode CurrentMode { get; private set; }
        public WeighingRecord CurrentRecord { get; private set; }
        public IScaleDriver ScaleDriver => _scaleDriver;

        /// <summary>
        /// 允许读数：秤已连接且重量稳定
        /// </summary>
        public bool IsReadingAllowed
        {
            get
            {
                return _scaleDriver.IsConnected &&
                       _scaleDriver.LastWeight != null &&
                       _scaleDriver.LastWeight.IsStable;
            }
        }

        public WeighingWorkflow(
            IWeighingRepository repository,
            IScaleDriver scaleDriver,
            AntiCheatConfig antiCheatConfig,
            string stationNo)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _scaleDriver = scaleDriver ?? throw new ArgumentNullException(nameof(scaleDriver));
            _antiCheatChecker = new AntiCheatChecker(antiCheatConfig ?? new AntiCheatConfig());
            _ticketGenerator = new TicketNumberGenerator(repository);

            CurrentMode = WeighingMode.Standard;
            CurrentRecord = new WeighingRecord();
        }

        /// <summary>
        /// 设置称重模式，重置当前记录
        /// </summary>
        public void SetWeighingMode(WeighingMode mode)
        {
            CurrentMode = mode;
            CurrentRecord = new WeighingRecord
            {
                ScaleMode = ((int)mode).ToString()
            };
        }

        /// <summary>
        /// 手动继续 — 清除当前记录，准备新一次称重
        /// </summary>
        public void Continue()
        {
            CurrentRecord = new WeighingRecord
            {
                ScaleMode = ((int)CurrentMode).ToString()
            };
        }

        /// <summary>
        /// 读取重量 — 从秤台获取当前重量并更新记录
        /// </summary>
        public WeightData ReadWeight()
        {
            WeightData weightData = _scaleDriver.GetCurrentWeight();

            if (weightData == null)
                return null;

            long weight = (long)weightData.Weight;

            if (weightData.IsGross)
            {
                // 毛重
                CurrentRecord.Gross = weight;
                CurrentRecord.GrossDateTime = weightData.Timestamp;
            }
            else
            {
                // 皮重
                CurrentRecord.Tare = weight;
                CurrentRecord.TareDateTime = weightData.Timestamp;
            }

            // 计算净重
            if (CurrentRecord.Gross.HasValue && CurrentRecord.Tare.HasValue)
            {
                CurrentRecord.Net = WeightCalculator.CalculateNet(
                    CurrentRecord.Gross.Value,
                    CurrentRecord.Tare.Value);
            }

            // 计算货物净重
            if (CurrentRecord.Net.HasValue)
            {
                CurrentRecord.ProductNet = WeightCalculator.CalculateProductNet(
                    CurrentRecord.Net.Value,
                    CurrentRecord.ExceptWater,
                    CurrentRecord.ExceptOther);
            }

            return weightData;
        }

        /// <summary>
        /// 保存记录 — 防作弊检查、生成磅单号、保存到数据库
        /// </summary>
        public bool SaveRecord()
        {
            // 1. 获取车辆信息用于防作弊检查
            TruckInfo truck = null;
            if (!string.IsNullOrEmpty(CurrentRecord.TruckNo))
            {
                truck = _repository.GetTruckByNumber(CurrentRecord.TruckNo);
            }

            // 2. 查询历史数据用于防作弊检查
            List<long> historyTareWeights = null;
            List<decimal> historyNetWeights = null;
            if (!string.IsNullOrEmpty(CurrentRecord.TruckNo))
            {
                var recentRecords = _repository.QueryRecords(new WeighingQueryCriteria
                {
                    DataType = "1",  // 交易记录
                    StartTime = DateTime.Now.AddDays(-30),
                    EndTime = DateTime.Now,
                    FieldConditions = new List<FieldCondition>
                    {
                        new FieldCondition { FieldName = "TruckNo", Operator = "=", Value = CurrentRecord.TruckNo }
                    }
                });
                historyTareWeights = recentRecords.Where(r => r.Tare.HasValue).Select(r => r.Tare.Value).ToList();
                historyNetWeights = recentRecords.Where(r => r.Net.HasValue).Select(r => (decimal)r.Net.Value).ToList();
            }

            // 3. 执行防作弊检查
            var checkResults = _antiCheatChecker.RunAllChecks(
                CurrentRecord,
                truck,
                DateTime.Now,
                historyTareWeights,
                historyNetWeights);

            var failedChecks = checkResults.Where(r => !r.IsPassed).ToList();
            if (failedChecks.Any())
            {
                // 设置报警标志
                foreach (var check in failedChecks)
                {
                    SetAlarmFlag(check.FlagField);
                }
                return false;
            }

            // 4. 生成磅单号
            CurrentRecord.TicketNo1 = _ticketGenerator.Generate(CurrentRecord.Station1 ?? "01");

            // 5. 设置称重时间
            if (!CurrentRecord.FirstDateTime.HasValue)
            {
                CurrentRecord.FirstDateTime = DateTime.Now;
            }
            CurrentRecord.SecondDateTime = DateTime.Now;

            // 6. 保存到数据库
            long id = _repository.SaveWeighingRecord(CurrentRecord);
            CurrentRecord.Id = id;

            return true;
        }

        /// <summary>
        /// 打印磅单 — MVP阶段为桩实现，调用报表层
        /// </summary>
        public void PrintTicket()
        {
            // TODO: 集成报表层 (ScaleControl.Reports) 进行磅单打印
            // MVP阶段为桩实现
            System.Diagnostics.Debug.Print(
                $"[PrintTicket] TicketNo={CurrentRecord.TicketNo1}, " +
                $"TruckNo={CurrentRecord.TruckNo}, " +
                $"Net={CurrentRecord.Net}");
        }

        /// <summary>
        /// 加载车皮信息 — 根据车号查询车辆信息并填充当前记录
        /// </summary>
        public void LoadTruckInfo(string truckNo)
        {
            if (string.IsNullOrEmpty(truckNo))
                return;

            TruckInfo truck = _repository.GetTruckByNumber(truckNo);
            if (truck == null)
                return;

            CurrentRecord.TruckNo = truck.TruckNo;
            CurrentRecord.Tare = truck.Tare;

            // 检查是否有未完成的临时记录
            WeighingRecord tempRecord = _repository.GetTempRecordByTruckNo(truckNo);
            if (tempRecord != null)
            {
                // 配对称重模式：恢复临时记录
                CurrentRecord = tempRecord;
            }
        }

        /// <summary>
        /// 设置报警标志字段
        /// </summary>
        private void SetAlarmFlag(string flagField)
        {
            switch (flagField)
            {
                case "TareWeightAlarmFlag":
                    CurrentRecord.TareWeightAlarmFlag = "1";
                    break;
                case "TareTimeAlarmFlag":
                    CurrentRecord.TareTimeAlarmFlag = "1";
                    break;
                case "WeightTimeAlarmFlag":
                    CurrentRecord.WeightTimeAlarmFlag = "1";
                    break;
                case "OwsCheckType":
                    CurrentRecord.OwsCheckType = "1";
                    break;
            }
        }
    }
}
