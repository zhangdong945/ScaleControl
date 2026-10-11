using System;
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
            // 从嵌入资源读取SQL脚本
            string sql = LoadSqlScript();
            using (var conn = _factory.CreateConnection())
            {
                conn.Open();
                // 按分号分割SQL语句（每句CREATE TABLE以分号结尾）
                var statements = sql.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var statement in statements)
                {
                    string trimmed = statement.Trim();
                    if (string.IsNullOrWhiteSpace(trimmed)) continue;
                    try
                    {
                        using (var cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = trimmed;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        // 忽略"表已存在"错误，其他错误抛出
                        string msg = ex.Message.ToLower();
                        if (!msg.Contains("already exists") && !msg.Contains("已存在"))
                        {
                            throw;
                        }
                    }
                }
            }
        }

        private static string LoadSqlScript()
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            string sql = null;
            foreach (var name in assembly.GetManifestResourceNames())
            {
                if (name.EndsWith("CreateAccessTables.sql"))
                {
                    using (var stream = assembly.GetManifestResourceStream(name))
                    using (var reader = new System.IO.StreamReader(stream))
                    {
                        sql = reader.ReadToEnd();
                    }
                    break;
                }
            }
            if (sql == null)
            {
                throw new System.InvalidOperationException("找不到数据库初始化脚本 CreateAccessTables.sql。");
            }
            return sql;
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
