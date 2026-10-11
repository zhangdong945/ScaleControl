using System;
using System.IO.Ports;
using System.Net.Sockets;
using System.Threading;
using ScaleControl.Models.Entities;
using ScaleControl.Models.Config;
using ScaleControl.Models.Enums;
using ScaleControl.Models.Interfaces;
using ScaleControl.Hardware.Protocol;

namespace ScaleControl.Hardware
{
    public class MettlerToledoScaleDriver : IScaleDriver, IDisposable
    {
        private SerialPort _serialPort;
        private TcpClient _tcpClient;
        private NetworkStream _networkStream;
        private ScaleConnectionConfig _config;
        private WeightData _lastWeight;
        private readonly object _lock = new object();

        // 稳态检测
        private decimal _stableStartWeight;
        private DateTime _stableStartTime;
        private bool _isCheckingStable;

        public int TerminalId => _config?.TerminalId ?? 0;
        public string TerminalName => _config?.TerminalName;
        public bool IsConnected => _serialPort?.IsOpen ?? (_tcpClient?.Connected ?? false);
        public WeightData LastWeight => _lastWeight;

        public event EventHandler<WeightData> WeightUpdated;
        public event EventHandler<string> ConnectionStatusChanged;

        public void Connect(ScaleConnectionConfig config)
        {
            _config = config;
            if (config.ConnectionType == ConnectionType.Serial)
            {
                _serialPort = new SerialPort(config.PortName, config.BaudRate)
                {
                    DataBits = config.DataBits,
                    StopBits = config.StopBits,
                    Parity = config.Parity,
                    ReadTimeout = 1000
                };
                _serialPort.DataReceived += OnSerialDataReceived;
                _serialPort.Open();
            }
            else
            {
                _tcpClient = new TcpClient();
                _tcpClient.Connect(config.IpAddress, config.Port);
                _networkStream = _tcpClient.GetStream();
                BeginReadTcp();
            }
            ConnectionStatusChanged?.Invoke(this, "已连接");
        }

        public void Disconnect()
        {
            _serialPort?.Close();
            _tcpClient?.Close();
            ConnectionStatusChanged?.Invoke(this, "已断开");
        }

        public WeightData GetCurrentWeight() => _lastWeight;

        public void SendCommand(string command)
        {
            if (!IsConnected) return;
            var bytes = System.Text.Encoding.ASCII.GetBytes(command);
            if (_serialPort?.IsOpen == true)
                _serialPort.Write(bytes, 0, bytes.Length);
            else if (_networkStream != null)
                _networkStream.Write(bytes, 0, bytes.Length);
        }

        private void OnSerialDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                int bytesToRead = _serialPort.BytesToRead;
                byte[] buffer = new byte[bytesToRead];
                _serialPort.Read(buffer, 0, bytesToRead);
                ProcessBuffer(buffer);
            }
            catch { }
        }

        private void BeginReadTcp()
        {
            byte[] buffer = new byte[256];
            _networkStream.BeginRead(buffer, 0, buffer.Length, ar =>
            {
                try
                {
                    int bytesRead = _networkStream.EndRead(ar);
                    if (bytesRead > 0)
                    {
                        byte[] data = new byte[bytesRead];
                        Array.Copy(buffer, data, bytesRead);
                        ProcessBuffer(data);
                    }
                    BeginReadTcp();
                }
                catch { }
            }, null);
        }

        private void ProcessBuffer(byte[] buffer)
        {
            // 查找STX (0x02) 并解析18字节帧
            for (int i = 0; i <= buffer.Length - 18; i++)
            {
                if (buffer[i] == 0x02)
                {
                    byte[] frame = new byte[18];
                    Array.Copy(buffer, i, frame, 0, 18);
                    var weightData = ToledoProtocolParser.Parse(frame);
                    if (weightData != null)
                    {
                        weightData = CheckStability(weightData);
                        _lastWeight = weightData;
                        WeightUpdated?.Invoke(this, weightData);
                    }
                }
            }
        }

        private WeightData CheckStability(WeightData data)
        {
            if (!_isCheckingStable)
            {
                _stableStartWeight = data.Weight;
                _stableStartTime = DateTime.Now;
                _isCheckingStable = true;
                data.IsStable = false;
                return data;
            }

            var elapsed = (DateTime.Now - _stableStartTime).TotalSeconds;
            var change = Math.Abs(data.Weight - _stableStartWeight);

            if (elapsed >= _config.StableDetectTime && change <= _config.StableAllowChange)
            {
                data.IsStable = true;
            }
            else if (change > _config.StableAllowChange)
            {
                _stableStartWeight = data.Weight;
                _stableStartTime = DateTime.Now;
                data.IsStable = false;
            }

            return data;
        }

        public void Dispose()
        {
            Disconnect();
            _serialPort?.Dispose();
            _networkStream?.Dispose();
            _tcpClient?.Dispose();
        }
    }
}
