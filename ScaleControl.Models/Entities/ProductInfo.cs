namespace ScaleControl.Models.Entities
{
    public class ProductInfo
    {
        public long Id { get; set; }
        public string ProductName { get; set; }         // 货物名称
        public string Code { get; set; }                // 编码
        public string InputCode { get; set; }           // 输入码
        public string Remark { get; set; }              // 备注
        public bool EnableMaxNetLimit { get; set; }     // 启用最大净重限制
        public long MaxNetLimit { get; set; }           // 最大净重限制值
    }
}
