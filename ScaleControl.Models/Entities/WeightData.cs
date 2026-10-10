using System;

namespace ScaleControl.Models.Entities
{
    public class WeightData
    {
        public decimal Weight { get; set; }           // 重量值 (kg)
        public bool IsStable { get; set; }            // 是否稳态
        public bool IsOverload { get; set; }          // 是否超载
        public bool IsUnderload { get; set; }         // 是否欠载
        public string Unit { get; set; } = "kg";      // 单位
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public int DecimalPlaces { get; set; } = 0;   // 小数点位置
        public int DivisionFactor { get; set; } = 1;  // 分度值因子
        public bool IsGross { get; set; } = true;     // true=毛重, false=净重

        public override string ToString()
        {
            return $"{Weight} {Unit} {(IsStable ? "稳定" : "波动")}";
        }
    }
}
