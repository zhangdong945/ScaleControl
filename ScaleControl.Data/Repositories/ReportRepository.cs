using System.Collections.Generic;
using System.Data;
using ScaleControl.Models.Entities;
using ScaleControl.Models.Interfaces;

namespace ScaleControl.Data.Repositories
{
    /// <summary>
    /// Repository for Report (report format) table.
    /// </summary>
    public class ReportRepository : RepositoryBase
    {
        public ReportRepository(IDatabaseConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public List<ReportInfo> GetReports()
        {
            var results = new List<ReportInfo>();
            using (var connection = CreateConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Report ORDER BY ReportName";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add(MapReportInfo(reader));
                        }
                    }
                }
            }
            return results;
        }

        public ReportInfo GetReportById(int reportId)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Report WHERE ReportId = @ReportId";
                    AddParameter(cmd, "@ReportId", reportId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapReportInfo(reader);
                        }
                    }
                }
            }
            return null;
        }

        private ReportInfo MapReportInfo(IDataReader reader)
        {
            return new ReportInfo
            {
                ReportId = System.Convert.ToInt32(reader["ReportId"]),
                ReportName = reader["ReportName"] as string,
                ReportCHNName = reader["ReportCHNName"] as string,
                ReportSQL = reader["ReportSQL"] as string,
                ReportType = reader["ReportType"] as string,
                Root = reader["Root"] as string
            };
        }
    }
}
