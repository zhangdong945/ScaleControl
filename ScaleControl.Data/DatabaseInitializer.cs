using System;
using System.IO;
using System.Reflection;
using System.Data.SqlClient;
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

        /// <summary>
        /// 从嵌入资源的空白数据库模板创建数据库
        /// </summary>
        public void CreateFromTemplate(string dbPath)
        {
            var assembly = Assembly.GetExecutingAssembly();
            string templateName = null;
            foreach (var name in assembly.GetManifestResourceNames())
            {
                if (name.EndsWith("empty_db.mdb"))
                {
                    templateName = name;
                    break;
                }
            }
            if (templateName == null)
            {
                throw new InvalidOperationException("找不到数据库模板文件 empty_db.mdb。");
            }
            using (var stream = assembly.GetManifestResourceStream(templateName))
            {
                using (var fileStream = new FileStream(dbPath, FileMode.Create))
                {
                    stream.CopyTo(fileStream);
                }
            }
        }

        /// <summary>
        /// 创建SQL Server数据库并执行建表脚本
        /// </summary>
        public void CreateSqlServerDatabase(string host, string database, string user, string password)
        {
            string masterConnStr = $"Server={host};Database=master;User Id={user};Password={password};";
            string dbConnStr = $"Server={host};Database={database};User Id={user};Password={password};";

            using (var conn = new SqlConnection(masterConnStr))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"IF DB_ID(N'{database}') IS NULL CREATE DATABASE [{database}]";
                    cmd.ExecuteNonQuery();
                }
            }

            string script = ReadEmbeddedScript();
            string[] statements = script.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            using (var conn = new SqlConnection(dbConnStr))
            {
                conn.Open();
                foreach (string statement in statements)
                {
                    string trimmed = statement.Trim();
                    if (string.IsNullOrEmpty(trimmed))
                    {
                        continue;
                    }
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = trimmed;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        private string ReadEmbeddedScript()
        {
            var assembly = Assembly.GetExecutingAssembly();
            string resourceName = null;
            foreach (var name in assembly.GetManifestResourceNames())
            {
                if (name.EndsWith("CreateSqlServerTables.sql"))
                {
                    resourceName = name;
                    break;
                }
            }
            if (resourceName == null)
            {
                throw new InvalidOperationException("找不到嵌入资源 CreateSqlServerTables.sql。");
            }
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public bool TestConnection()
        {
            try
            {
                using (var conn = _factory.CreateConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
