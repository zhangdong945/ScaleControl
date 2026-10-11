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
            var statements = ParseSqlStatements(sql);
            using (var conn = _factory.CreateConnection())
            {
                conn.Open();
                int tableIndex = 0;
                foreach (var statement in statements)
                {
                    tableIndex++;
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
                        // 忽略"表已存在"错误
                        string msg = ex.Message.ToLower();
                        if (!msg.Contains("already exists") && !msg.Contains("已存在")
                            && !msg.Contains("could not find file")
                            && !msg.Contains("不能找到"))
                        {
                            throw new System.InvalidOperationException(
                                $"创建第{tableIndex}个表失败: {ex.Message}\nSQL: {trimmed.Substring(0, System.Math.Min(100, trimmed.Length))}...", ex);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 解析SQL脚本，每个CREATE TABLE作为独立语句
        /// </summary>
        private static System.Collections.Generic.List<string> ParseSqlStatements(string sql)
        {
            var statements = new System.Collections.Generic.List<string>();
            var lines = sql.Split(new[] { '\n' }, System.StringSplitOptions.None);
            var currentStatement = new System.Text.StringBuilder();
            foreach (var line in lines)
            {
                string trimmedLine = line.Trim();
                if (string.IsNullOrWhiteSpace(trimmedLine)) continue;
                currentStatement.AppendLine(line);
                // 遇到分号表示语句结束
                if (trimmedLine.EndsWith(";"))
                {
                    statements.Add(currentStatement.ToString().TrimEnd(';'));
                    currentStatement.Clear();
                }
            }
            // 处理最后没有分号的语句
            if (currentStatement.Length > 0)
            {
                statements.Add(currentStatement.ToString());
            }
            return statements;
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
