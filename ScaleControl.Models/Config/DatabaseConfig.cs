namespace ScaleControl.Models.Config
{
    public class DatabaseConfig
    {
        public string Provider { get; set; } = "Access";  // Access / SqlServer

        // Access
        public string AccessDatabasePath { get; set; } = "Data\\ScaleDB.mdb";
        public string AccessPassword { get; set; } = "sss2014aw";

        // SQL Server
        public string SqlServerHost { get; set; }
        public string SqlDatabase { get; set; }
        public string SqlUser { get; set; }
        public string SqlPassword { get; set; }

        public string GetAccessConnectionString()
        {
            return $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={AccessDatabasePath};Jet OLEDB:Database Password={AccessPassword}";
        }

        public string GetSqlServerConnectionString()
        {
            return $"Server={SqlServerHost};Database={SqlDatabase};User Id={SqlUser};Password={SqlPassword}";
        }
    }
}
