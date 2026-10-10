using System.Data;
using System.IO;
using System.Reflection;
using ScaleControl.Models.Interfaces;

namespace ScaleControl.Data
{
    public class DatabaseInitializer
    {
        private readonly IDatabaseConnectionFactory _factory;

        public DatabaseInitializer(IDatabaseConnectionFactory factory)
        {
            _factory = factory;
        }

        public void Initialize()
        {
            using var conn = _factory.CreateConnection();
            conn.Open();
            var sql = File.ReadAllText("Scripts/CreateAccessTables.sql");
            foreach (var batch in sql.Split(new[] { "GO" }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (string.IsNullOrWhiteSpace(batch)) continue;
                using var cmd = conn.CreateCommand();
                cmd.CommandText = batch.Trim();
                cmd.ExecuteNonQuery();
            }
        }

        public bool TestConnection()
        {
            try
            {
                using var conn = _factory.CreateConnection();
                conn.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
