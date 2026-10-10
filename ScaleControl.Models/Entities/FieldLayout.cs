namespace ScaleControl.Models.Entities
{
    public class FieldLayout
    {
        public string ScaleMode { get; set; }         // 称重模式
        public string FieldName { get; set; }         // 字段名称
        public string CtrlName { get; set; }          // 控件名称
        public int Top { get; set; }                  // 上边距
        public int Left { get; set; }                 // 左边距
        public int Height { get; set; }               // 高度
        public int Width { get; set; }                // 宽度
        public string FontName { get; set; }          // 字体名称
        public float FontSize { get; set; }           // 字体大小
        public bool FontItalic { get; set; }          // 斜体
        public bool FontBold { get; set; }            // 粗体
        public string BackColor { get; set; }         // 背景色
        public string ForeColor { get; set; }         // 前景色
        public string LabelCaption { get; set; }      // 标签标题
        public int TabOrder { get; set; }             // Tab顺序
        public bool IsVisible { get; set; }           // 是否可见
        public bool IsReadOnly { get; set; }          // 是否只读
        public bool IsClear { get; set; }             // 是否清空
        public bool IsMustFill { get; set; }          // 是否必填
        public bool IsMustExist { get; set; }         // 是否必须存在
        public string Formula { get; set; }           // 公式
    }
}
