using System;

namespace ScaleControl.Models.Entities
{
    public class LogQueryCriteria
    {
        public DateTime? StartTime { get; set; }      // 开始时间
        public DateTime? EndTime { get; set; }        // 结束时间
        public string OperationType { get; set; }     // 操作类型
    }
}
