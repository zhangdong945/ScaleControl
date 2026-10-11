using ScaleControl.Models.Entities;

namespace ScaleControl.Hardware.Protocol
{
    public static class ToledoProtocolParser
    {
        public static WeightData Parse(byte[] data)
        {
            if (data == null || data.Length < 18) return null;
            if (data[0] != 0x02) return null; // STX 校验

            var weightData = new WeightData();

            // 状态字A (字节1)
            byte statusA = data[1];
            int decimalPlaces = statusA & 0x07;
            int divisionFactor = (statusA >> 3) & 0x03;
            weightData.DecimalPlaces = decimalPlaces;
            weightData.DivisionFactor = GetDivisionFactor(divisionFactor);

            // 状态字B (字节2)
            byte statusB = data[2];
            weightData.IsGross = (statusB & 0x01) == 0;
            bool isNegative = (statusB & 0x02) != 0;
            weightData.IsOverload = (statusB & 0x04) != 0;

            // 重量值 (字节3-8, 6位ASCII字符)
            string weightStr = System.Text.Encoding.ASCII.GetString(data, 3, 6).Trim();
            if (decimal.TryParse(weightStr, out decimal rawWeight))
            {
                decimal multiplier = GetMultiplier(decimalPlaces);
                weightData.Weight = isNegative ? -rawWeight * multiplier : rawWeight * multiplier;
            }

            weightData.IsUnderload = weightData.Weight < 0;

            return weightData;
        }

        private static int GetDivisionFactor(int divisionFactor)
        {
            switch (divisionFactor)
            {
                case 1: return 1;
                case 2: return 2;
                case 3: return 5;
                default: return 1;
            }
        }

        private static decimal GetMultiplier(int decimalPlaces)
        {
            switch (decimalPlaces)
            {
                case 0: return 100m;
                case 1: return 10m;
                case 2: return 1m;
                case 3: return 0.1m;
                case 4: return 0.01m;
                default: return 1m;
            }
        }
    }
}
