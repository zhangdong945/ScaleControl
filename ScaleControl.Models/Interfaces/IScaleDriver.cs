using System;
using ScaleControl.Models.Entities;
using ScaleControl.Models.Config;

namespace ScaleControl.Models.Interfaces
{
    public interface IScaleDriver
    {
        int TerminalId { get; }
        string TerminalName { get; }
        bool IsConnected { get; }
        WeightData LastWeight { get; }

        event EventHandler<WeightData> WeightUpdated;
        event EventHandler<string> ConnectionStatusChanged;

        void Connect(ScaleConnectionConfig config);
        void Disconnect();
        WeightData GetCurrentWeight();
        void SendCommand(string command);  // C/T/P/Z 命令
    }
}
