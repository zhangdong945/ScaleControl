using System;
using System.Collections.Generic;
using System.Linq;
using ScaleControl.Models.Entities;
using ScaleControl.Models.Enums;

namespace ScaleControl.Core
{
    /// <summary>
    /// 防作弊检查结果
    /// </summary>
    public class AntiCheatCheckResult
    {
        public bool IsPassed { get; set; }
        public string AlarmType { get; set; }
        public string Message { get; set; }
        public string FlagField { get; set; }
    }

    /// <summary>
    /// 防作弊报警配置
    /// </summary>
    public class AntiCheatConfig
    {
        // 1. 皮重有效期检查
        public bool EnableTareValidity { get; set; } = true;

        // 2. 净重区间检查
        public bool EnableNetRange { get; set; } = true;
        public long MinNetWeight { get; set; }
        public long MaxNetWeight { get; set; }

        // 3. 毛重区间检查
        public bool EnableGrossRange { get; set; } = true;
        public long MinGrossWeight { get; set; }
        public long MaxGrossWeight { get; set; }

        // 4. 皮重差异报警
        public bool EnableTareDiff { get; set; } = true;
        public bool TareDiffByPercentage { get; set; } = false;  // false=按绝对值, true=按百分比
        public decimal TareDiffThreshold { get; set; } = 100;  // 绝对值(kg)或百分比(%)
        public bool UseHistoryAvgTare { get; set; } = true;     // true=按历史平均皮重, false=按车辆存储皮重

        // 5. 配对时间差报警
        public bool EnablePairTimeDiff { get; set; } = true;
        public int PairTimeDiffMinutes { get; set; } = 30;

        // 6. 交易时间差报警
        public bool EnableTradeTimeDiff { get; set; } = true;
        public int TradeTimeDiffMinutes { get; set; } = 30;

        // 7. 收发货重量检查
        public bool EnableWeightDiff { get; set; } = true;
        public bool WeightDiffByPercentage { get; set; } = true;  // false=按绝对值, true=按百分比
        public decimal WeightDiffThreshold { get; set; } = 5;  // 绝对值(kg)或百分比(%)

        // 8. 超载检查
        public bool EnableOverload { get; set; } = true;

        // 9. 净重差异报警
        public bool EnableNetDiff { get; set; } = true;
        public bool NetDiffByPercentage { get; set; } = true;  // false=按绝对值, true=按百分比
        public decimal NetDiffThreshold { get; set; } = 10;  // 绝对值(kg)或百分比(%)
    }

    /// <summary>
    /// 防作弊检查器 — 9项防作弊报警检查
    /// </summary>
    public class AntiCheatChecker
    {
        private readonly AntiCheatConfig _config;

        public AntiCheatChecker(AntiCheatConfig config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        /// <summary>
        /// 1. 皮重有效期检查 — 如果 truck.EffectDay > 0, 检查 (Now - TareDate).TotalDays > EffectDay
        /// </summary>
        public AntiCheatCheckResult CheckTareValidity(WeighingRecord record, TruckInfo truck, DateTime now)
        {
            if (!_config.EnableTareValidity)
                return new AntiCheatCheckResult { IsPassed = true };

            if (truck == null)
                return new AntiCheatCheckResult { IsPassed = true };

            if (truck.EffectDay > 0)
            {
                double daysDiff = (now - truck.TareDate).TotalDays;
                if (daysDiff > truck.EffectDay)
                {
                    return new AntiCheatCheckResult
                    {
                        IsPassed = false,
                        AlarmType = "TareValidity",
                        Message = "皮重有效期已超出，禁止保存数据",
                        FlagField = "TareTimeAlarmFlag"
                    };
                }
            }

            return new AntiCheatCheckResult { IsPassed = true };
        }

        /// <summary>
        /// 2. 净重区间检查 — 如果 Net.HasValue, 检查 MinNetWeight <= Net <= MaxNetWeight
        /// </summary>
        public AntiCheatCheckResult CheckNetRange(WeighingRecord record)
        {
            if (!_config.EnableNetRange)
                return new AntiCheatCheckResult { IsPassed = true };

            if (!record.Net.HasValue)
                return new AntiCheatCheckResult { IsPassed = true };

            long net = record.Net.Value;
            if (net < _config.MinNetWeight || net > _config.MaxNetWeight)
            {
                return new AntiCheatCheckResult
                {
                    IsPassed = false,
                    AlarmType = "NetRange",
                    Message = "净重超差，不允许保存数据",
                    FlagField = "WeightTimeAlarmFlag"
                };
            }

            return new AntiCheatCheckResult { IsPassed = true };
        }

        /// <summary>
        /// 3. 毛重区间检查 — 如果 Gross.HasValue, 检查 MinGrossWeight <= Gross <= MaxGrossWeight
        /// </summary>
        public AntiCheatCheckResult CheckGrossRange(WeighingRecord record)
        {
            if (!_config.EnableGrossRange)
                return new AntiCheatCheckResult { IsPassed = true };

            if (!record.Gross.HasValue)
                return new AntiCheatCheckResult { IsPassed = true };

            long gross = record.Gross.Value;
            if (gross < _config.MinGrossWeight || gross > _config.MaxGrossWeight)
            {
                return new AntiCheatCheckResult
                {
                    IsPassed = false,
                    AlarmType = "GrossRange",
                    Message = "毛重超差，不允许保存数据",
                    FlagField = "WeightTimeAlarmFlag"
                };
            }

            return new AntiCheatCheckResult { IsPassed = true };
        }

        /// <summary>
        /// 4. 皮重差异报警 — 比较当前皮重与车辆存储皮重或历史平均皮重, 超差报警
        /// </summary>
        public AntiCheatCheckResult CheckTareDiff(WeighingRecord record, TruckInfo truck, List<long> historyTareWeights)
        {
            if (!_config.EnableTareDiff)
                return new AntiCheatCheckResult { IsPassed = true };

            if (!record.Tare.HasValue)
                return new AntiCheatCheckResult { IsPassed = true };

            long currentTare = record.Tare.Value;
            long referenceTare;

            // 确定参考皮重
            if (_config.UseHistoryAvgTare && historyTareWeights != null && historyTareWeights.Count > 0)
            {
                referenceTare = (long)historyTareWeights.Average();
            }
            else if (truck != null)
            {
                referenceTare = truck.Tare;
            }
            else
            {
                return new AntiCheatCheckResult { IsPassed = true };
            }

            if (referenceTare == 0)
                return new AntiCheatCheckResult { IsPassed = true };

            long diff = Math.Abs(currentTare - referenceTare);

            if (_config.TareDiffByPercentage)
            {
                decimal percentage = (decimal)diff / referenceTare * 100m;
                if (percentage > _config.TareDiffThreshold)
                {
                    return new AntiCheatCheckResult
                    {
                        IsPassed = false,
                        AlarmType = "TareDiff",
                        Message = "皮重差异超差，不允许保存数据",
                        FlagField = "TareWeightAlarmFlag"
                    };
                }
            }
            else
            {
                if (diff > _config.TareDiffThreshold)
                {
                    return new AntiCheatCheckResult
                    {
                        IsPassed = false,
                        AlarmType = "TareDiff",
                        Message = "皮重差异超差，不允许保存数据",
                        FlagField = "TareWeightAlarmFlag"
                    };
                }
            }

            return new AntiCheatCheckResult { IsPassed = true };
        }

        /// <summary>
        /// 5. 配对时间差报警 — 配对称重模式下, 检查 |GrossDateTime - TareDateTime| <= PairTimeDiffMinutes
        /// </summary>
        public AntiCheatCheckResult CheckPairTimeDiff(WeighingRecord record)
        {
            if (!_config.EnablePairTimeDiff)
                return new AntiCheatCheckResult { IsPassed = true };

            // 仅对配对称重模式检查
            if (!int.TryParse(record.ScaleMode, out int mode) || mode != (int)WeighingMode.Paired)
                return new AntiCheatCheckResult { IsPassed = true };

            if (!record.GrossDateTime.HasValue || !record.TareDateTime.HasValue)
                return new AntiCheatCheckResult { IsPassed = true };

            double minutesDiff = Math.Abs((record.GrossDateTime.Value - record.TareDateTime.Value).TotalMinutes);
            if (minutesDiff > _config.PairTimeDiffMinutes)
            {
                return new AntiCheatCheckResult
                {
                    IsPassed = false,
                    AlarmType = "PairTimeDiff",
                    Message = "车辆长期异常停留，不允许保存数据",
                    FlagField = "WeightTimeAlarmFlag"
                };
            }

            return new AntiCheatCheckResult { IsPassed = true };
        }

        /// <summary>
        /// 6. 交易时间差报警 — 检查 |FirstDateTime - SecondDateTime| <= TradeTimeDiffMinutes
        /// </summary>
        public AntiCheatCheckResult CheckTradeTimeDiff(WeighingRecord record)
        {
            if (!_config.EnableTradeTimeDiff)
                return new AntiCheatCheckResult { IsPassed = true };

            if (!record.FirstDateTime.HasValue || !record.SecondDateTime.HasValue)
                return new AntiCheatCheckResult { IsPassed = true };

            double minutesDiff = Math.Abs((record.FirstDateTime.Value - record.SecondDateTime.Value).TotalMinutes);
            if (minutesDiff > _config.TradeTimeDiffMinutes)
            {
                return new AntiCheatCheckResult
                {
                    IsPassed = false,
                    AlarmType = "TradeTimeDiff",
                    Message = "车辆行驶时间异常，不允许保存数据",
                    FlagField = "WeightTimeAlarmFlag"
                };
            }

            return new AntiCheatCheckResult { IsPassed = true };
        }

        /// <summary>
        /// 7. 收发货重量检查 — 比较净重与订单/合同重量(货物净重), 超差报警
        /// </summary>
        public AntiCheatCheckResult CheckWeightDiff(WeighingRecord record)
        {
            if (!_config.EnableWeightDiff)
                return new AntiCheatCheckResult { IsPassed = true };

            if (!record.Net.HasValue)
                return new AntiCheatCheckResult { IsPassed = true };

            // 货物净重作为收发货参考重量
            decimal orderWeight = record.ProductNet;
            if (orderWeight <= 0)
                return new AntiCheatCheckResult { IsPassed = true };

            long net = record.Net.Value;
            decimal diff = Math.Abs(net - orderWeight);

            if (_config.WeightDiffByPercentage)
            {
                decimal percentage = diff / orderWeight * 100m;
                if (percentage > _config.WeightDiffThreshold)
                {
                    return new AntiCheatCheckResult
                    {
                        IsPassed = false,
                        AlarmType = "WeightDiff",
                        Message = "收发货重量超差，不允许保存数据",
                        FlagField = "WeightTimeAlarmFlag"
                    };
                }
            }
            else
            {
                if (diff > _config.WeightDiffThreshold)
                {
                    return new AntiCheatCheckResult
                    {
                        IsPassed = false,
                        AlarmType = "WeightDiff",
                        Message = "收发货重量超差，不允许保存数据",
                        FlagField = "WeightTimeAlarmFlag"
                    };
                }
            }

            return new AntiCheatCheckResult { IsPassed = true };
        }

        /// <summary>
        /// 8. 超载检查 — 检查 Gross <= MaxGross, Net <= MaxNet
        /// </summary>
        public AntiCheatCheckResult CheckOverload(WeighingRecord record, TruckInfo truck)
        {
            if (!_config.EnableOverload)
                return new AntiCheatCheckResult { IsPassed = true };

            // 优先使用车辆信息中的限载值, 其次使用记录中的限载值
            int? maxGross = truck?.MaxGross ?? record.MaxGross;
            int? maxNet = truck?.MaxNet ?? record.MaxNet;

            // 检查毛重超载
            if (maxGross.HasValue && record.Gross.HasValue)
            {
                if (record.Gross.Value > maxGross.Value)
                {
                    return new AntiCheatCheckResult
                    {
                        IsPassed = false,
                        AlarmType = "Overload",
                        Message = "车辆超载，不允许保存数据",
                        FlagField = "OwsCheckType"
                    };
                }
            }

            // 检查净重超载
            if (maxNet.HasValue && record.Net.HasValue)
            {
                if (record.Net.Value > maxNet.Value)
                {
                    return new AntiCheatCheckResult
                    {
                        IsPassed = false,
                        AlarmType = "Overload",
                        Message = "车辆超载，不允许保存数据",
                        FlagField = "OwsCheckType"
                    };
                }
            }

            return new AntiCheatCheckResult { IsPassed = true };
        }

        /// <summary>
        /// 9. 净重差异报警 — 比较当前净重与历史平均净重, 超差报警
        /// </summary>
        public AntiCheatCheckResult CheckNetDiff(WeighingRecord record, TruckInfo truck, List<decimal> historyNetWeights)
        {
            if (!_config.EnableNetDiff)
                return new AntiCheatCheckResult { IsPassed = true };

            if (!record.Net.HasValue)
                return new AntiCheatCheckResult { IsPassed = true };

            // 使用历史平均净重作为参考值
            if (historyNetWeights == null || historyNetWeights.Count == 0)
                return new AntiCheatCheckResult { IsPassed = true };

            decimal referenceNet = historyNetWeights.Average();
            if (referenceNet <= 0)
                return new AntiCheatCheckResult { IsPassed = true };

            decimal net = record.Net.Value;
            decimal diff = Math.Abs(net - referenceNet);

            if (_config.NetDiffByPercentage)
            {
                decimal percentage = diff / referenceNet * 100m;
                if (percentage > _config.NetDiffThreshold)
                {
                    return new AntiCheatCheckResult
                    {
                        IsPassed = false,
                        AlarmType = "NetDiff",
                        Message = "净重差异超差，不允许保存数据",
                        FlagField = "WeightTimeAlarmFlag"
                    };
                }
            }
            else
            {
                if (diff > _config.NetDiffThreshold)
                {
                    return new AntiCheatCheckResult
                    {
                        IsPassed = false,
                        AlarmType = "NetDiff",
                        Message = "净重差异超差，不允许保存数据",
                        FlagField = "WeightTimeAlarmFlag"
                    };
                }
            }

            return new AntiCheatCheckResult { IsPassed = true };
        }

        /// <summary>
        /// 执行所有已启用的防作弊检查
        /// </summary>
        public List<AntiCheatCheckResult> RunAllChecks(
            WeighingRecord record,
            TruckInfo truck,
            DateTime now,
            List<long> historyTareWeights = null,
            List<decimal> historyNetWeights = null)
        {
            var results = new List<AntiCheatCheckResult>();

            results.Add(CheckTareValidity(record, truck, now));
            results.Add(CheckNetRange(record));
            results.Add(CheckGrossRange(record));
            results.Add(CheckTareDiff(record, truck, historyTareWeights));
            results.Add(CheckPairTimeDiff(record));
            results.Add(CheckTradeTimeDiff(record));
            results.Add(CheckWeightDiff(record));
            results.Add(CheckOverload(record, truck));
            results.Add(CheckNetDiff(record, truck, historyNetWeights));

            return results;
        }
    }
}
