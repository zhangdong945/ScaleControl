using System.Data;
using System.Data.SqlClient;
using ScaleControl.Models.Config;
using ScaleControl.Models.Interfaces;

namespace ScaleControl.Data
{
    public class SqlConnectionFactory : IDatabaseConnectionFactory
    {
        private readonly string _connectionString;
        public string ProviderName => "SqlServer";

        public SqlConnectionFactory(DatabaseConfig config)
        {
            _connectionString = config.GetSqlServerConnectionString();
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
