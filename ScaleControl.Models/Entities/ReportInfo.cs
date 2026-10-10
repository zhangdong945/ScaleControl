namespace ScaleControl.Models.Entities
{
    public class ReportInfo
    {
        public int ReportId { get; set; }             // 报表Id
        public string ReportName { get; set; }        // 报表名称
        public string ReportCHNName { get; set; }     // 报表中文名
        public string ReportSQL { get; set; }         // 报表SQL
        public string ReportType { get; set; }        // 报表类型
        public string Root { get; set; }              // 根路径
    }
}
