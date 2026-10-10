using System;
using System.Collections.Generic;

namespace ScaleControl.Models.Entities
{
    public class WeighingQueryCriteria
    {
        public string DataType { get; set; }                          // 数据类型
        public DateTime? StartTime { get; set; }                      // 开始时间
        public DateTime? EndTime { get; set; }                        // 结束时间
        public List<FieldCondition> FieldConditions { get; set; }     // 字段条件列表
    }

    public class FieldCondition
    {
        public string FieldName { get; set; }     // 字段名
        public string Operator { get; set; }      // 运算符
        public string Value { get; set; }         // 值
    }
}
