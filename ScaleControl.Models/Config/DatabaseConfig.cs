using System.Xml.Serialization;

namespace ScaleControl.Models.Config
{
    [XmlRoot("DatabaseSettings")]
    public class DatabaseConfig
    {
        [XmlElement("EnableLocalDb")]
        public bool EnableLocalDb { get; set; } = true;

        [XmlElement("EnableSqlServer")]
        public bool EnableSqlServer { get; set; } = false;

        [XmlElement("Provider")]
        public string Provider { get; set; } = "Access";  // Access / SqlServer

        [XmlElement("AccessDatabasePath")]
        public string AccessDatabasePath { get; set; } = "database\\sc.mdb";

        [XmlElement("AccessPassword")]
        public string AccessPassword { get; set; } = "sss2014aw";

        [XmlElement("SqlServerHost")]
        public string SqlServerHost { get; set; }

        [XmlElement("SqlDatabase")]
        public string SqlDatabase { get; set; }

        [XmlElement("SqlUser")]
        public string SqlUser { get; set; }

        [XmlElement("SqlPassword")]
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
