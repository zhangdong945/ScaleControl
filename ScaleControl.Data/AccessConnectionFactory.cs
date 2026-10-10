using System.Data;
using System.Data.OleDb;
using ScaleControl.Models.Config;
using ScaleControl.Models.Interfaces;

namespace ScaleControl.Data
{
    public class AccessConnectionFactory : IDatabaseConnectionFactory
    {
        private readonly string _connectionString;
        public string ProviderName => "Access";

        public AccessConnectionFactory(DatabaseConfig config)
        {
            _connectionString = config.GetAccessConnectionString();
        }

        public IDbConnection CreateConnection()
        {
            return new OleDbConnection(_connectionString);
        }
    }
}
