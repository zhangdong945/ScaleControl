namespace ScaleControl.Models.Entities
{
    public class UserInfo
    {
        public long Id { get; set; }
        public string UserId { get; set; }        // 用户Id
        public string LogName { get; set; }       // 登录名
        public string UserName { get; set; }      // 用户名
        public string GroupName { get; set; }     // 所属组
        public string Password { get; set; }      // 密码
        public string Remark { get; set; }        // 备注
    }
}
