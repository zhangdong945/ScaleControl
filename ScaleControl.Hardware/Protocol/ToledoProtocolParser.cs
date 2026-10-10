using ScaleControl.Models.Entities;

namespace ScaleControl.Hardware.Protocol
{
    public static class ToledoProtocolParser
    {
        public static WeightData Parse(byte[] data)
        {
            if (data == null || data.Length < 17) return null;
            if (data[0] != 0x02) return null; // STX check

            var weightData = new WeightData();

            // Status word A (byte 1)
            byte statusA = data[1];
            int decimalPlaces = statusA & 0x07;
            int divisionFactor = (statusA >> 3) & 0x03;
            weightData.DecimalPlaces = decimalPlaces;
            weightData.DivisionFactor = divisionFactor switch { 1 => 1, 2 => 2, 3 => 5, _ => 1 };

            // Status word B (byte 2)
            byte statusB = data[2];
            weightData.IsGross = (statusB & 0x01) == 0;
            bool isNegative = (statusB & 0x02) != 0;
            weightData.IsOverload = (statusB & 0x04) != 0;
            weightData.IsUnderload = weightData.Weight < 0;

            // Weight value (bytes 3-8, 6 ASCII chars)
            string weightStr = System.Text.Encoding.ASCII.GetString(data, 2, 6).Trim();
            if (decimal.TryParse(weightStr, out decimal rawWeight))
            {
                decimal multiplier = decimalPlaces switch
                {
                    0 => 100m,
                    1 => 10m,
                    2 => 1m,
                    3 => 0.1m,
                    4 => 0.01m,
                    _ => 1m
                };
                weightData.Weight = isNegative ? -rawWeight * multiplier : rawWeight * multiplier;
            }

            return weightData;
        }
    }
}
