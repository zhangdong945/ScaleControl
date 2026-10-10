namespace ScaleControl.Models.Entities
{
    public class RolePermission
    {
        public int GroupId { get; set; }          // 角色Id
        public int ModelId { get; set; }          // 模块Id
        public string ModelChnName { get; set; }  // 模块中文名
        public bool Search { get; set; }          // 查询权限
        public bool Edit { get; set; }            // 编辑权限
        public bool Other1 { get; set; }          // 其他权限1
        public bool Other2 { get; set; }          // 其他权限2
    }
}
