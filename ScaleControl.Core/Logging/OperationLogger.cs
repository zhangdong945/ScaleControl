using ScaleControl.Models.Entities;
using ScaleControl.Models.Interfaces;

namespace ScaleControl.Core.Logging
{
    public class OperationLogger
    {
        private readonly IWeighingRepository _repository;

        public OperationLogger(IWeighingRepository repository)
        {
            _repository = repository;
        }

        public void Log(string operationType, string keyValue, string operatorName,
            string moduleName, string beforeData = null, string afterData = null, string reason = null)
        {
            _repository.WriteLog(new OperationLog
            {
                KeyValue = keyValue,
                Operator = operatorName,
                LogTime = DateTime.Now,
                OptType = operationType,
                ModuleName = moduleName,
                LogBeforeData = beforeData,
                LogAfterData = afterData,
                Reason = reason
            });
        }
    }
}
