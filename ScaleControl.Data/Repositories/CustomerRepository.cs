using System.Collections.Generic;
using System.Data;
using ScaleControl.Models.Entities;
using ScaleControl.Models.Interfaces;

namespace ScaleControl.Data.Repositories
{
    /// <summary>
    /// Repository for SenderList and ReceiverList (customer/supplier management) tables.
    /// </summary>
    public class CustomerRepository : RepositoryBase
    {
        public CustomerRepository(IDatabaseConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public void SaveSender(CustomerInfo customer)
        {
            SaveCustomer(customer, "SenderList");
        }

        public void SaveReceiver(CustomerInfo customer)
        {
            SaveCustomer(customer, "ReceiverList");
        }

        public List<CustomerInfo> GetSenders(string filter)
        {
            return GetCustomers(filter, "SenderList");
        }

        public List<CustomerInfo> GetReceivers(string filter)
        {
            return GetCustomers(filter, "ReceiverList");
        }

        #region Private Helper Methods

        private void SaveCustomer(CustomerInfo customer, string tableName)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                if (customer.Id > 0)
                {
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = $"UPDATE {tableName} SET Name = @Name, InputCode = @InputCode, Remark = @Remark WHERE Id = @Id";
                        AddParameter(cmd, "@Name", customer.Name);
                        AddParameter(cmd, "@InputCode", customer.InputCode);
                        AddParameter(cmd, "@Remark", customer.Remark);
                        AddParameter(cmd, "@Id", customer.Id);
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = $"INSERT INTO {tableName} (Name, InputCode, Remark) VALUES (@Name, @InputCode, @Remark)";
                        AddParameter(cmd, "@Name", customer.Name);
                        AddParameter(cmd, "@InputCode", customer.InputCode);
                        AddParameter(cmd, "@Remark", customer.Remark);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        private List<CustomerInfo> GetCustomers(string filter, string tableName)
        {
            var results = new List<CustomerInfo>();
            using (var connection = CreateConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    if (string.IsNullOrEmpty(filter))
                    {
                        cmd.CommandText = $"SELECT * FROM {tableName} ORDER BY Name";
                    }
                    else
                    {
                        cmd.CommandText = $"SELECT * FROM {tableName} WHERE Name LIKE @Filter OR InputCode LIKE @Filter ORDER BY Name";
                        AddParameter(cmd, "@Filter", "%" + filter + "%");
                    }
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add(new CustomerInfo
                            {
                                Id = System.Convert.ToInt64(reader["Id"]),
                                Name = reader["Name"] as string,
                                InputCode = reader["InputCode"] as string,
                                Remark = reader["Remark"] as string
                            });
                        }
                    }
                }
            }
            return results;
        }

        #endregion
    }
}
