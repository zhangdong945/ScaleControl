using System;
using ScaleControl.Models.Enums;

namespace ScaleControl.Models.Entities
{
    public class WeighingRecord
    {
        public long Id { get; set; }
        public string TicketNo1 { get; set; }          // 临时磅单号
        public string TicketNo2 { get; set; }          // 交易磅单号
        public string Station1 { get; set; }           // 临时磅站
        public string Station2 { get; set; }           // 交易磅站
        public string ScaleNo1 { get; set; }           // 临时秤号
        public string ScaleNo2 { get; set; }           // 交易秤号
        public string TruckNo { get; set; }            // 车号
        public string CardNo { get; set; }             // 卡号
        public string ContractNo { get; set; }         // 合同号
        public string Product { get; set; }            // 货物名称
        public string ProductCode { get; set; }        // 产品编码
        public string Specification { get; set; }      // 规格
        public string Sender { get; set; }             // 发货单位
        public string Receiver { get; set; }           // 收货单位
        public string Transporter { get; set; }        // 运输单位
        public DateTime? FirstDateTime { get; set; }   // 临时称重时间
        public DateTime? SecondDateTime { get; set; }  // 交易称重时间
        public DateTime? GrossDateTime { get; set; }   // 毛重称重时间
        public DateTime? TareDateTime { get; set; }    // 皮重称重时间
        public long? FirstWeight { get; set; }         // 临时重量
        public long? SecondWeight { get; set; }        // 交易重量
        public long? Gross { get; set; }               // 毛重
        public long? Tare { get; set; }                // 皮重
        public long? Net { get; set; }                 // 净重
        public decimal ProductNet { get; set; }        // 货物净重
        public decimal ExceptWater { get; set; }       // 扣水
        public decimal ExceptOther { get; set; }       // 扣杂
        public string UserId1 { get; set; }            // 临时操作员Id
        public string UserName1 { get; set; }          // 临时操作员名
        public string UserId2 { get; set; }            // 交易操作员Id
        public string UserName2 { get; set; }          // 交易操作员名
        public string Bc1 { get; set; }                // 临时班次
        public string Bc2 { get; set; }                // 交易班次
        public string ScaleWeightFlag { get; set; }    // 自动处理标识
        public string SpareFlag { get; set; }          // 备用标识
        public string UploadFlag { get; set; } = "0";  // 上传标识
        public string DataEditFlag { get; set; } = "0";// 修改标识
        public string DataStatus { get; set; } = "1";  // 数据状态
        public string ManualInputFlag { get; set; } = "0"; // 手工补单
        public string ScaleMode { get; set; }          // 称重模式
        public string FinalFlag { get; set; } = "0";  // 结束标识
        public long? LeftWeight { get; set; }          // 订单余额
        public string TareWeightAlarmFlag { get; set; } = "0";
        public string TareTimeAlarmFlag { get; set; } = "0";
        public string WeightTimeAlarmFlag { get; set; } = "0";
        public string AutoSaveFlag { get; set; } = "0";
        public string AuthFlag { get; set; } = "0";    // 授权标志
        public string Driver { get; set; }             // 司机
        public string BusinessNo { get; set; }         // 业务单号
        public string IdNumber { get; set; }           // 身份证号
        public string BusinessType { get; set; }       // 业务类型
        public int? MaxGross { get; set; }             // 最大毛重
        public int? MaxNet { get; set; }               // 最大净重
        public string OwsCheckType { get; set; }       // 超限类型
        public int ReprintCount { get; set; }          // 补打次数
        public string IdentifyTruckNo1 { get; set; }   // 临时识别车号
        public string IdentifyTruckNo2 { get; set; }   // 交易识别车号

        // 备用字段
        public string SpareStr1 { get; set; }
        public string SpareStr2 { get; set; }
        // ... SpareStr3-15
        public decimal SpareNum1 { get; set; }
        // ... SpareNum2-8
    }
}
