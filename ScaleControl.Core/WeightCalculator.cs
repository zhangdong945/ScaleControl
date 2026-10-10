using ScaleControl.Models.Entities;
using ScaleControl.Models.Enums;

namespace ScaleControl.Core
{
    public static class WeightCalculator
    {
        /// <summary>
        /// 标准称重: 净重 = 毛重 - 皮重
        /// </summary>
        public static long CalculateNet(long gross, long tare)
        {
            return gross - tare;
        }

        /// <summary>
        /// 配对称重: 比较两次重量，大=毛重，小=皮重
        /// </summary>
        public static (long gross, long tare, long net) CalculatePaired(long firstWeight, long secondWeight)
        {
            long gross = System.Math.Max(firstWeight, secondWeight);
            long tare = System.Math.Min(firstWeight, secondWeight);
            long net = gross - tare;
            return (gross, tare, net);
        }

        /// <summary>
        /// 计算货物净重 = 净重 - 扣水 - 扣杂
        /// </summary>
        public static decimal CalculateProductNet(long netWeight, decimal exceptWater, decimal exceptOther)
        {
            return netWeight - exceptWater - exceptOther;
        }

        /// <summary>
        /// 计算扣包装重量
        /// </summary>
        public static decimal CalculatePackageWeight(int packageCount, decimal packageWeightPerUnit)
        {
            return packageCount * packageWeightPerUnit;
        }

        /// <summary>
        /// kg 转 吨
        /// </summary>
        public static decimal KgToTon(long kg)
        {
            return kg / 1000m;
        }
    }
}
