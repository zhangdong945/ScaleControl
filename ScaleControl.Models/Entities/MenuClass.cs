namespace ScaleControl.Models.Entities
{
    public class MenuClass
    {
        public int ClassId { get; set; }          // 菜单类Id
        public string ChnText { get; set; }       // 中文文本
        public string EngText { get; set; }       // 英文文本
        public int Order { get; set; }            // 排序
    }
}
