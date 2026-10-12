using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ScaleControl.Data
{
    /// <summary>
    /// 将本地Access数据库的全部数据表同步到新创建的SQL Server网络数据库。
    /// </summary>
    public class DatabaseSynchronizer
    {
        private readonly string _accessConnectionString;
        private readonly string _sqlConnectionString;
        private readonly List<string> _syncLog = new List<string>();

        /// <summary>
        /// 需要同步的所有表名（参考表 + 业务流水表）。
        /// </summary>
        private static readonly string[] TablesToSync = new[]
        {
            "TruckList",
            "ProductList",
            "SenderList",
            "ReceiverList",
            "TransporterList",
            "CardInfo",
            "Contractlist",
            "UserList",
            "UserGroup",
            "UserRoleCtrl",
            "StationList",
            "SysMenuClassList",
            "SysMenuList",
            "Report",
            "TFieldNameList",
            "MainPosition",
            "SpareStr1",
            "SpareStr2",
            "SpareStr3",
            "SpareStr4",
            "SpareStr5",
            "SpareStr6",
            "SpareStr7",
            "SpareStr8",
            "SpecifList",
            "KeyList",
            "Trade",
            "LogInfo",
            "PictureList",
            "TrendLineList"
        };

        public DatabaseSynchronizer(string accessConnectionString, string sqlConnectionString)
        {
            _accessConnectionString = accessConnectionString;
            _sqlConnectionString = sqlConnectionString;
        }

        /// <summary>
        /// 同步日志，每行格式为 "  表名: 同步 N 条记录" 或 "  表名: 失败 - 原因"
        /// </summary>
        public string SyncLog => string.Join(Environment.NewLine, _syncLog);

        /// <summary>
        /// 执行同步：从本地Access读取各参考表数据，写入目标SQL Server数据库。
        /// </summary>
        public void Synchronize()
        {
            _syncLog.Clear();

            foreach (string tableName in TablesToSync)
            {
                try
                {
                    int count = SyncTable(tableName);
                    if (count > 0)
                    {
                        _syncLog.Add($"  {tableName}: 同步 {count} 条记录");
                    }
                }
                catch (Exception ex)
                {
                    _syncLog.Add($"  {tableName}: 失败 - {ex.Message}");
                }
            }
        }

        private int SyncTable(string tableName)
        {
            // 1. 从Access读取数据
            DataTable dataTable;
            using (var accessConn = new OleDbConnection(_accessConnectionString))
            {
                accessConn.Open();
                string query = $"SELECT * FROM [{tableName}]";
                using (var cmd = new OleDbCommand(query, accessConn))
                using (var adapter = new OleDbDataAdapter(cmd))
                {
                    dataTable = new DataTable();
                    adapter.Fill(dataTable);
                }
            }

            if (dataTable.Rows.Count == 0)
                return 0;

            // 2. 确定SQL Server中实际存在的列（取交集，避免Access中有而SQL Server中没有的列导致报错）
            List<string> columns = GetCommonColumns(tableName, dataTable);
            if (columns.Count == 0)
                return 0;

            // 3. 构造INSERT语句
            string columnList = string.Join(", ", columns.Select(c => $"[{c}]"));
            string valueList = string.Join(", ", columns.Select(c => $"@{c}"));
            string insertSql = $"INSERT INTO [{tableName}] ({columnList}) VALUES ({valueList})";

            bool hasIdentity = HasIdentityColumn(tableName);

            int insertedCount = 0;

            // 4. 写入SQL Server
            using (var sqlConn = new SqlConnection(_sqlConnectionString))
            {
                sqlConn.Open();

                if (hasIdentity)
                {
                    ExecuteNonQuery(sqlConn, $"SET IDENTITY_INSERT [{tableName}] ON");
                }

                try
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        using (var cmd = new SqlCommand(insertSql, sqlConn))
                        {
                            foreach (string col in columns)
                            {
                                object value = row[col];
                                cmd.Parameters.AddWithValue($"@{col}", value ?? DBNull.Value);
                            }
                            cmd.ExecuteNonQuery();
                            insertedCount++;
                        }
                    }
                }
                finally
                {
                    if (hasIdentity)
                    {
                        ExecuteNonQuery(sqlConn, $"SET IDENTITY_INSERT [{tableName}] OFF");
                    }
                }
            }

            return insertedCount;
        }

        /// <summary>
        /// 获取SQL Server目标表中与Access DataTable共有的列名（大小写不敏感）。
        /// </summary>
        private List<string> GetCommonColumns(string tableName, DataTable dataTable)
        {
            var sqlColumns = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            using (var sqlConn = new SqlConnection(_sqlConnectionString))
            {
                sqlConn.Open();
                using (var cmd = new SqlCommand(
                    "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @table", sqlConn))
                {
                    cmd.Parameters.AddWithValue("@table", tableName);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sqlColumns.Add(reader.GetString(0));
                        }
                    }
                }
            }

            var commonColumns = new List<string>();
            foreach (DataColumn col in dataTable.Columns)
            {
                if (sqlColumns.Contains(col.ColumnName))
                {
                    commonColumns.Add(col.ColumnName);
                }
            }

            return commonColumns;
        }

        /// <summary>
        /// 判断指定表是否包含IDENTITY列。
        /// </summary>
        private bool HasIdentityColumn(string tableName)
        {
            // TruckList 的主键 TruckNo 不是IDENTITY列，其余表均有IDENTITY主键。
            return !string.Equals(tableName, "TruckList", StringComparison.OrdinalIgnoreCase);
        }

        private void ExecuteNonQuery(SqlConnection conn, string sql)
        {
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}
