using System;

namespace ScaleControl.Models.Entities
{
    public class TruckInfo
    {
        public long Id { get; set; }
        public string TruckNo { get; set; }      // 车号 (主键)
        public long Tare { get; set; }           // 皮重
        public DateTime TareDate { get; set; }   // 皮重时间
        public string InputCode { get; set; }    // 输入码
        public long EffectDay { get; set; }      // 有效天数
        public string Remark { get; set; }       // 备注
        public int? MaxGross { get; set; }       // 最大毛重
        public int? MaxNet { get; set; }         // 最大净重
        public string OwsCheckType { get; set; } // 超限类型
    }
}
