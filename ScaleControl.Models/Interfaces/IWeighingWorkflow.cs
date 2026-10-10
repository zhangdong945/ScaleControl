using ScaleControl.Models.Entities;
using ScaleControl.Models.Enums;

namespace ScaleControl.Models.Interfaces
{
    public interface IWeighingWorkflow
    {
        WeighingMode CurrentMode { get; }
        bool IsReadingAllowed { get; }

        void SetWeighingMode(WeighingMode mode);
        void Continue();                    // 手动继续
        WeightData ReadWeight();            // 读数
        bool SaveRecord();                  // 保存
        void PrintTicket();                 // 打印
        void LoadTruckInfo(string truckNo); // 加载车皮信息
        WeighingRecord CurrentRecord { get; }
    }
}
