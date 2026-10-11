using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ScaleControl.Models.Entities;
using ScaleControl.Models.Interfaces;

namespace ScaleControl.Data.Repositories
{
    /// <summary>
    /// Repository for LogInfo (operation log) table.
    /// </summary>
    public class LogRepository : RepositoryBase
    {
        public LogRepository(IDatabaseConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public void WriteLog(OperationLog log)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO LogInfo (KeyValue, Operator, LogTime, OptType, ModuleId, ModuleName, LogBeforeData, LogAfterData, Reason)
                        VALUES (@KeyValue, @Operator, @LogTime, @OptType, @ModuleId, @ModuleName, @LogBeforeData, @LogAfterData, @Reason)";
                    AddParameter(cmd, "@KeyValue", log.KeyValue);
                    AddParameter(cmd, "@Operator", log.Operator);
                    AddParameter(cmd, "@LogTime", log.LogTime == default(DateTime) ? DateTime.Now : log.LogTime);
                    AddParameter(cmd, "@OptType", log.OptType);
                    AddParameter(cmd, "@ModuleId", log.ModuleId);
                    AddParameter(cmd, "@ModuleName", log.ModuleName);
                    AddParameter(cmd, "@LogBeforeData", log.LogBeforeData);
                    AddParameter(cmd, "@LogAfterData", log.LogAfterData);
                    AddParameter(cmd, "@Reason", log.Reason);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<OperationLog> QueryLogs(LogQueryCriteria criteria)
        {
            var results = new List<OperationLog>();
            using (var connection = CreateConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    var sb = new StringBuilder("SELECT * FROM LogInfo WHERE 1=1");

                    if (criteria != null)
                    {
                        if (criteria.StartTime.HasValue)
                        {
                            sb.Append(" AND LogTime >= @StartTime");
                            AddParameter(cmd, "@StartTime", criteria.StartTime.Value);
                        }

                        if (criteria.EndTime.HasValue)
                        {
                            sb.Append(" AND LogTime <= @EndTime");
                            AddParameter(cmd, "@EndTime", criteria.EndTime.Value);
                        }

                        if (!string.IsNullOrEmpty(criteria.OperationType))
                        {
                            sb.Append(" AND OptType = @OptType");
                            AddParameter(cmd, "@OptType", criteria.OperationType);
                        }
                    }

                    sb.Append(" ORDER BY LogTime DESC");

                    cmd.CommandText = sb.ToString();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add(new OperationLog
                            {
                                LogId = Convert.ToInt64(reader["LogId"]),
                                KeyValue = reader["KeyValue"] as string,
                                Operator = reader["Operator"] as string,
                                LogTime = reader["LogTime"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["LogTime"]),
                                OptType = reader["OptType"] as string,
                                ModuleId = reader["ModuleId"] as string,
                                ModuleName = reader["ModuleName"] as string,
                                LogBeforeData = reader["LogBeforeData"] as string,
                                LogAfterData = reader["LogAfterData"] as string,
                                Reason = reader["Reason"] as string
                            });
                        }
                    }
                }
            }
            return results;
        }
    }
}
