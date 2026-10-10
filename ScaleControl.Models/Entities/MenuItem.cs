namespace ScaleControl.Models.Entities
{
    public class MenuItem
    {
        public int MenuId { get; set; }           // 菜单项Id
        public int ClassId { get; set; }          // 所属菜单类Id
        public string ChnText { get; set; }       // 中文文本
        public string EngText { get; set; }       // 英文文本
        public int ImageIndex { get; set; }       // 图标索引
        public int Order { get; set; }            // 排序
        public bool CanUseFlag { get; set; }      // 可用标志
        public string OperatorText { get; set; }  // 操作文本
    }
}
