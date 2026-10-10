using System.Collections.Generic;
using ScaleControl.Models.Entities;

namespace ScaleControl.Models.Interfaces
{
    public interface IWeighingRepository
    {
        // 称重记录
        WeighingRecord GetById(long id);
        WeighingRecord GetByTicketNo(string ticketNo);
        long SaveWeighingRecord(WeighingRecord record);
        void UpdateWeighingRecord(WeighingRecord record);
        void DeleteWeighingRecord(long id);
        List<WeighingRecord> QueryRecords(WeighingQueryCriteria criteria);
        WeighingRecord GetTempRecordByTruckNo(string truckNo);

        // 车皮管理
        TruckInfo GetTruckByNumber(string truckNo);
        void SaveTruck(TruckInfo truck);
        void DeleteTruck(string truckNo);
        List<TruckInfo> QueryTrucks(string filter);

        // 货物管理
        ProductInfo GetProductByName(string name);
        void SaveProduct(ProductInfo product);
        List<ProductInfo> GetProducts(string filter);

        // 收发货单位
        void SaveSender(CustomerInfo customer);
        void SaveReceiver(CustomerInfo customer);
        List<CustomerInfo> GetSenders(string filter);
        List<CustomerInfo> GetReceivers(string filter);

        // 用户认证
        UserInfo ValidateUser(string loginName, string password);
        void SaveUser(UserInfo user);
        void UpdatePassword(string userId, string newPassword);
        List<UserInfo> GetUsers();

        // 角色权限
        List<RoleInfo> GetRoles();
        RoleInfo GetRoleById(int roleId);
        void SaveRole(RoleInfo role);
        List<RolePermission> GetRolePermissions(int roleId);
        void SaveRolePermissions(int roleId, List<RolePermission> permissions);

        // 磅单号
        string GenerateTicketNo(string stationNo);

        // 日志
        void WriteLog(OperationLog log);
        List<OperationLog> QueryLogs(LogQueryCriteria criteria);

        // 菜单
        List<MenuClass> GetMenuClasses();
        List<MenuItem> GetMenuItems(int classId);

        // 报表格式
        List<ReportInfo> GetReports();
        ReportInfo GetReportById(int reportId);

        // 界面布局
        List<FieldLayout> getFieldLayouts(string weighingMode);
        void SaveFieldLayouts(List<FieldLayout> layouts, string weighingMode);
    }
}
