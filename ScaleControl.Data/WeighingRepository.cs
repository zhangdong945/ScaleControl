using System;
using System.Collections.Generic;
using ScaleControl.Models.Entities;
using ScaleControl.Models.Interfaces;
using ScaleControl.Data.Repositories;

namespace ScaleControl.Data
{
    /// <summary>
    /// Facade repository that aggregates all individual per-table repositories.
    /// Maintains backward compatibility with the original IWeighingRepository interface.
    /// </summary>
    public class WeighingRepository : IWeighingRepository
    {
        private readonly TradeRepository _tradeRepository;
        private readonly TruckRepository _truckRepository;
        private readonly ProductRepository _productRepository;
        private readonly CustomerRepository _customerRepository;
        private readonly UserRepository _userRepository;
        private readonly RoleRepository _roleRepository;
        private readonly LogRepository _logRepository;
        private readonly MenuRepository _menuRepository;
        private readonly ReportRepository _reportRepository;
        private readonly FieldLayoutRepository _fieldLayoutRepository;
        private readonly TicketNumberGenerator _ticketNumberGenerator;

        public WeighingRepository(IDatabaseConnectionFactory connectionFactory)
        {
            if (connectionFactory == null)
                throw new ArgumentNullException(nameof(connectionFactory));

            _tradeRepository = new TradeRepository(connectionFactory);
            _truckRepository = new TruckRepository(connectionFactory);
            _productRepository = new ProductRepository(connectionFactory);
            _customerRepository = new CustomerRepository(connectionFactory);
            _userRepository = new UserRepository(connectionFactory);
            _roleRepository = new RoleRepository(connectionFactory);
            _logRepository = new LogRepository(connectionFactory);
            _menuRepository = new MenuRepository(connectionFactory);
            _reportRepository = new ReportRepository(connectionFactory);
            _fieldLayoutRepository = new FieldLayoutRepository(connectionFactory);
            _ticketNumberGenerator = new TicketNumberGenerator(connectionFactory);
        }

        #region Weighing Records

        public WeighingRecord GetById(long id)
        {
            return _tradeRepository.GetById(id);
        }

        public WeighingRecord GetByTicketNo(string ticketNo)
        {
            return _tradeRepository.GetByTicketNo(ticketNo);
        }

        public long SaveWeighingRecord(WeighingRecord record)
        {
            return _tradeRepository.SaveWeighingRecord(record);
        }

        public void UpdateWeighingRecord(WeighingRecord record)
        {
            _tradeRepository.UpdateWeighingRecord(record);
        }

        public void DeleteWeighingRecord(long id)
        {
            _tradeRepository.DeleteWeighingRecord(id);
        }

        public List<WeighingRecord> QueryRecords(WeighingQueryCriteria criteria)
        {
            return _tradeRepository.QueryRecords(criteria);
        }

        public WeighingRecord GetTempRecordByTruckNo(string truckNo)
        {
            return _tradeRepository.GetTempRecordByTruckNo(truckNo);
        }

        #endregion

        #region Truck Management

        public TruckInfo GetTruckByNumber(string truckNo)
        {
            return _truckRepository.GetTruckByNumber(truckNo);
        }

        public void SaveTruck(TruckInfo truck)
        {
            _truckRepository.SaveTruck(truck);
        }

        public void DeleteTruck(string truckNo)
        {
            _truckRepository.DeleteTruck(truckNo);
        }

        public List<TruckInfo> QueryTrucks(string filter)
        {
            return _truckRepository.QueryTrucks(filter);
        }

        #endregion

        #region Product Management

        public ProductInfo GetProductByName(string name)
        {
            return _productRepository.GetProductByName(name);
        }

        public void SaveProduct(ProductInfo product)
        {
            _productRepository.SaveProduct(product);
        }

        public List<ProductInfo> GetProducts(string filter)
        {
            return _productRepository.GetProducts(filter);
        }

        #endregion

        #region Customer Management (Senders/Receivers)

        public void SaveSender(CustomerInfo customer)
        {
            _customerRepository.SaveSender(customer);
        }

        public void SaveReceiver(CustomerInfo customer)
        {
            _customerRepository.SaveReceiver(customer);
        }

        public List<CustomerInfo> GetSenders(string filter)
        {
            return _customerRepository.GetSenders(filter);
        }

        public List<CustomerInfo> GetReceivers(string filter)
        {
            return _customerRepository.GetReceivers(filter);
        }

        #endregion

        #region User Authentication

        public UserInfo ValidateUser(string loginName, string password)
        {
            return _userRepository.ValidateUser(loginName, password);
        }

        public void SaveUser(UserInfo user)
        {
            _userRepository.SaveUser(user);
        }

        public void UpdatePassword(string userId, string newPassword)
        {
            _userRepository.UpdatePassword(userId, newPassword);
        }

        public List<UserInfo> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        #endregion

        #region Role and Permission Management

        public List<RoleInfo> GetRoles()
        {
            return _roleRepository.GetRoles();
        }

        public RoleInfo GetRoleById(int roleId)
        {
            return _roleRepository.GetRoleById(roleId);
        }

        public void SaveRole(RoleInfo role)
        {
            _roleRepository.SaveRole(role);
        }

        public List<RolePermission> GetRolePermissions(int roleId)
        {
            return _roleRepository.GetRolePermissions(roleId);
        }

        public void SaveRolePermissions(int roleId, List<RolePermission> permissions)
        {
            _roleRepository.SaveRolePermissions(roleId, permissions);
        }

        #endregion

        #region Ticket Number Generation

        public string GenerateTicketNo(string stationNo)
        {
            return _ticketNumberGenerator.GenerateTicketNo(stationNo);
        }

        #endregion

        #region Logging

        public void WriteLog(OperationLog log)
        {
            _logRepository.WriteLog(log);
        }

        public List<OperationLog> QueryLogs(LogQueryCriteria criteria)
        {
            return _logRepository.QueryLogs(criteria);
        }

        #endregion

        #region Menu

        public List<MenuClass> GetMenuClasses()
        {
            return _menuRepository.GetMenuClasses();
        }

        public List<MenuItem> GetMenuItems(int classId)
        {
            return _menuRepository.GetMenuItems(classId);
        }

        #endregion

        #region Report Management

        public List<ReportInfo> GetReports()
        {
            return _reportRepository.GetReports();
        }

        public ReportInfo GetReportById(int reportId)
        {
            return _reportRepository.GetReportById(reportId);
        }

        #endregion

        #region Field Layout

        public List<FieldLayout> getFieldLayouts(string weighingMode)
        {
            return _fieldLayoutRepository.GetFieldLayouts(weighingMode);
        }

        public void SaveFieldLayouts(List<FieldLayout> layouts, string weighingMode)
        {
            _fieldLayoutRepository.SaveFieldLayouts(layouts, weighingMode);
        }

        #endregion
    }
}
