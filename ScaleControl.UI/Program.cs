using System;
using System.Windows.Forms;
using ScaleControl.Models.Entities;
using ScaleControl.Models.Interfaces;

namespace ScaleControl.UI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // MVP: Create stub dependencies for the main form
            // In production, these would be injected via DI container
            IWeighingWorkflow workflow = CreateWorkflowStub();
            IWeighingRepository repository = CreateRepositoryStub();
            UserInfo currentUser = new UserInfo
            {
                UserId = "001",
                LogName = "admin",
                UserName = "管理员"
            };

            Application.Run(new frmMain(workflow, repository, currentUser));
        }

        private static IWeighingWorkflow CreateWorkflowStub()
        {
            // MVP: Return a stub workflow. In production, this would be
            // a fully configured WeighingWorkflow with real scale driver.
            return new StubWorkflow();
        }

        private static IWeighingRepository CreateRepositoryStub()
        {
            // MVP: Return a stub repository. In production, this would be
            // a real database-backed repository.
            return new StubRepository();
        }
    }

    /// <summary>
    /// MVP stub implementation of IWeighingWorkflow for design-time support.
    /// </summary>
    internal class StubWorkflow : IWeighingWorkflow
    {
        private WeighingRecord _currentRecord = new WeighingRecord();

        public Models.Enums.WeighingMode CurrentMode => Models.Enums.WeighingMode.Standard;
        public bool IsReadingAllowed => false;
        public WeighingRecord CurrentRecord => _currentRecord;

        public void SetWeighingMode(Models.Enums.WeighingMode mode) { }
        public void Continue() { _currentRecord = new WeighingRecord(); }
        public WeightData ReadWeight() => null;
        public bool SaveRecord() => true;
        public void PrintTicket() { }
        public void LoadTruckInfo(string truckNo) { }
    }

    /// <summary>
    /// MVP stub implementation of IWeighingRepository for design-time support.
    /// </summary>
    internal class StubRepository : IWeighingRepository
    {
        public WeighingRecord GetById(long id) => null;
        public WeighingRecord GetByTicketNo(string ticketNo) => null;
        public long SaveWeighingRecord(WeighingRecord record) => 0;
        public void UpdateWeighingRecord(WeighingRecord record) { }
        public void DeleteWeighingRecord(long id) { }
        public System.Collections.Generic.List<WeighingRecord> QueryRecords(WeighingQueryCriteria criteria) => new System.Collections.Generic.List<WeighingRecord>();
        public WeighingRecord GetTempRecordByTruckNo(string truckNo) => null;
        public TruckInfo GetTruckByNumber(string truckNo) => null;
        public void SaveTruck(TruckInfo truck) { }
        public void DeleteTruck(string truckNo) { }
        public System.Collections.Generic.List<TruckInfo> QueryTrucks(string filter) => new System.Collections.Generic.List<TruckInfo>();
        public ProductInfo GetProductByName(string name) => null;
        public void SaveProduct(ProductInfo product) { }
        public System.Collections.Generic.List<ProductInfo> GetProducts(string filter) => new System.Collections.Generic.List<ProductInfo>();
        public void SaveSender(CustomerInfo customer) { }
        public void SaveReceiver(CustomerInfo customer) { }
        public System.Collections.Generic.List<CustomerInfo> GetSenders(string filter) => new System.Collections.Generic.List<CustomerInfo>();
        public System.Collections.Generic.List<CustomerInfo> GetReceivers(string filter) => new System.Collections.Generic.List<CustomerInfo>();
        public UserInfo ValidateUser(string loginName, string password) => null;
        public void SaveUser(UserInfo user) { }
        public void UpdatePassword(string userId, string newPassword) { }
        public System.Collections.Generic.List<UserInfo> GetUsers() => new System.Collections.Generic.List<UserInfo>();
        public System.Collections.Generic.List<RoleInfo> GetRoles() => new System.Collections.Generic.List<RoleInfo>();
        public RoleInfo GetRoleById(int roleId) => null;
        public void SaveRole(RoleInfo role) { }
        public System.Collections.Generic.List<RolePermission> GetRolePermissions(int roleId) => new System.Collections.Generic.List<RolePermission>();
        public void SaveRolePermissions(int roleId, System.Collections.Generic.List<RolePermission> permissions) { }
        public string GenerateTicketNo(string stationNo) => "";
        public void WriteLog(OperationLog log) { }
        public System.Collections.Generic.List<OperationLog> QueryLogs(LogQueryCriteria criteria) => new System.Collections.Generic.List<OperationLog>();
        public System.Collections.Generic.List<MenuClass> GetMenuClasses() => new System.Collections.Generic.List<MenuClass>();
        public System.Collections.Generic.List<MenuItem> GetMenuItems(int classId) => new System.Collections.Generic.List<MenuItem>();
        public System.Collections.Generic.List<ReportInfo> GetReports() => new System.Collections.Generic.List<ReportInfo>();
        public ReportInfo GetReportById(int reportId) => null;
        public System.Collections.Generic.List<FieldLayout> getFieldLayouts(string weighingMode) => new System.Collections.Generic.List<FieldLayout>();
        public void SaveFieldLayouts(System.Collections.Generic.List<FieldLayout> layouts, string weighingMode) { }
    }
}
