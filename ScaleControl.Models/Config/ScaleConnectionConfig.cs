using ScaleControl.Models.Enums;

namespace ScaleControl.Models.Config
{
    public class ScaleConnectionConfig
    {
        public int TerminalId { get; set; }
        public string TerminalName { get; set; }
        public string DeviceName { get; set; } = "标准MT仪表";
        public string ScaleType { get; set; } = "MettlerToledoStatic";
        public bool Enabled { get; set; } = true;
        public ConnectionType ConnectionType { get; set; } = ConnectionType.Serial;

        // 串口参数
        public string PortName { get; set; } = "COM1";
        public int BaudRate { get; set; } = 9600;
        public int DataBits { get; set; } = 8;
        public StopBits StopBits { get; set; } = StopBits.One;
        public Parity Parity { get; set; } = Parity.None;

        // 网络参数
        public string IpAddress { get; set; }
        public int Port { get; set; } = 8000;

        // 稳态判断参数
        public int StableDetectTime { get; set; } = 3;    // 秒
        public int StableAllowChange { get; set; } = 20;  // kg
        public int MinWeight { get; set; } = 1000;        // kg
    }
}
