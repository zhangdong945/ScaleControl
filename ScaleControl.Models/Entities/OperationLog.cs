using System;

namespace ScaleControl.Models.Entities
{
    public class OperationLog
    {
        public long LogId { get; set; }               // 日志Id
        public string KeyValue { get; set; }          // 关键值
        public string Operator { get; set; }          // 操作人
        public DateTime LogTime { get; set; }         // 操作时间
        public string OptType { get; set; }           // 操作类型
        public string ModuleId { get; set; }          // 模块Id
        public string ModuleName { get; set; }        // 模块名称
        public string LogBeforeData { get; set; }     // 操作前数据
        public string LogAfterData { get; set; }      // 操作后数据
        public string Reason { get; set; }            // 原因
    }
}
