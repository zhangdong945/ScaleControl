using System;
using System.Data;
using ScaleControl.Models.Interfaces;

namespace ScaleControl.Data.Repositories
{
    /// <summary>
    /// Generates unique ticket numbers for weighing records.
    /// </summary>
    public class TicketNumberGenerator
    {
        private readonly IDatabaseConnectionFactory _connectionFactory;

        public TicketNumberGenerator(IDatabaseConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
        }

        public string GenerateTicketNo(string stationNo)
        {
            var today = DateTime.Now.ToString("yyyyMMdd");
            var prefix = "T" + today;

            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    // Query max ticket number for today
                    cmd.CommandText = "SELECT MAX(TicketNo1) FROM Trade WHERE TicketNo1 LIKE @Prefix";
                    AddParameter(cmd, "@Prefix", prefix + "%");
                    var result = cmd.ExecuteScalar();

                    int sequence = 1;
                    if (result != null && result != DBNull.Value)
                    {
                        var maxTicket = result as string;
                        if (!string.IsNullOrEmpty(maxTicket) && maxTicket.Length > prefix.Length)
                        {
                            var seqStr = maxTicket.Substring(prefix.Length);
                            if (int.TryParse(seqStr, out int existingSeq))
                            {
                                sequence = existingSeq + 1;
                            }
                        }
                    }

                    return prefix + sequence.ToString("D4");
                }
            }
        }

        private void AddParameter(IDbCommand cmd, string name, object value)
        {
            var parameter = cmd.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = value ?? DBNull.Value;
            cmd.Parameters.Add(parameter);
        }
    }
}
