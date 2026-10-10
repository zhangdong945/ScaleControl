namespace ScaleControl.Models.Entities
{
    public class CustomerInfo
    {
        public long Id { get; set; }
        public string Name { get; set; }          // 单位名称
        public string InputCode { get; set; }     // 输入码
        public string Remark { get; set; }        // 备注
    }
}
