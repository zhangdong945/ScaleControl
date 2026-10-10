using ScaleControl.Models.Config;
using ScaleControl.Models.Interfaces;

namespace ScaleControl.Hardware
{
    public static class ScaleDriverFactory
    {
        public static IScaleDriver CreateDriver(ScaleConnectionConfig config)
        {
            return config.ScaleType switch
            {
                "MettlerToledoStatic" => new MettlerToledoScaleDriver(),
                _ => throw new System.NotSupportedException($"不支持的仪表类型: {config.ScaleType}")
            };
        }
    }
}
