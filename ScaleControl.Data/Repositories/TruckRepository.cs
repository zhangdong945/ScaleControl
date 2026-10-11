using System;
using System.Collections.Generic;
using System.Data;
using ScaleControl.Models.Entities;
using ScaleControl.Models.Interfaces;

namespace ScaleControl.Data.Repositories
{
    /// <summary>
    /// Repository for TruckList (truck/car management) table.
    /// </summary>
    public class TruckRepository : RepositoryBase
    {
        public TruckRepository(IDatabaseConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public TruckInfo GetTruckByNumber(string truckNo)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM TruckList WHERE TruckNo = @TruckNo";
                    AddParameter(cmd, "@TruckNo", truckNo);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapTruckInfo(reader);
                        }
                    }
                }
            }
            return null;
        }

        public void SaveTruck(TruckInfo truck)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                // Check if truck exists
                using (var checkCmd = connection.CreateCommand())
                {
                    checkCmd.CommandText = "SELECT COUNT(*) FROM TruckList WHERE TruckNo = @TruckNo";
                    AddParameter(checkCmd, "@TruckNo", truck.TruckNo);
                    var count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        // Update
                        using (var cmd = connection.CreateCommand())
                        {
                            cmd.CommandText = @"UPDATE TruckList SET Tare = @Tare, TareDate = @TareDate,
                                InputCode = @InputCode, EffectDay = @EffectDay, Remark = @Remark,
                                MaxGross = @MaxGross, MaxNet = @MaxNet, OwsCheckType = @OwsCheckType
                                WHERE TruckNo = @TruckNo";
                            AddParameter(cmd, "@Tare", truck.Tare);
                            AddParameter(cmd, "@TareDate", truck.TareDate);
                            AddParameter(cmd, "@InputCode", truck.InputCode);
                            AddParameter(cmd, "@EffectDay", truck.EffectDay);
                            AddParameter(cmd, "@Remark", truck.Remark);
                            AddParameter(cmd, "@MaxGross", (object)truck.MaxGross ?? DBNull.Value);
                            AddParameter(cmd, "@MaxNet", (object)truck.MaxNet ?? DBNull.Value);
                            AddParameter(cmd, "@OwsCheckType", truck.OwsCheckType);
                            AddParameter(cmd, "@TruckNo", truck.TruckNo);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        // Insert
                        using (var cmd = connection.CreateCommand())
                        {
                            cmd.CommandText = @"INSERT INTO TruckList (TruckNo, Tare, TareDate, InputCode, EffectDay, Remark, MaxGross, MaxNet, OwsCheckType)
                                VALUES (@TruckNo, @Tare, @TareDate, @InputCode, @EffectDay, @Remark, @MaxGross, @MaxNet, @OwsCheckType)";
                            AddParameter(cmd, "@TruckNo", truck.TruckNo);
                            AddParameter(cmd, "@Tare", truck.Tare);
                            AddParameter(cmd, "@TareDate", truck.TareDate);
                            AddParameter(cmd, "@InputCode", truck.InputCode);
                            AddParameter(cmd, "@EffectDay", truck.EffectDay);
                            AddParameter(cmd, "@Remark", truck.Remark);
                            AddParameter(cmd, "@MaxGross", (object)truck.MaxGross ?? DBNull.Value);
                            AddParameter(cmd, "@MaxNet", (object)truck.MaxNet ?? DBNull.Value);
                            AddParameter(cmd, "@OwsCheckType", truck.OwsCheckType);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public void DeleteTruck(string truckNo)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM TruckList WHERE TruckNo = @TruckNo";
                    AddParameter(cmd, "@TruckNo", truckNo);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<TruckInfo> QueryTrucks(string filter)
        {
            var results = new List<TruckInfo>();
            using (var connection = CreateConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    if (string.IsNullOrEmpty(filter))
                    {
                        cmd.CommandText = "SELECT * FROM TruckList ORDER BY TruckNo";
                    }
                    else
                    {
                        cmd.CommandText = "SELECT * FROM TruckList WHERE TruckNo LIKE @Filter OR InputCode LIKE @Filter ORDER BY TruckNo";
                        AddParameter(cmd, "@Filter", "%" + filter + "%");
                    }
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add(MapTruckInfo(reader));
                        }
                    }
                }
            }
            return results;
        }

        private TruckInfo MapTruckInfo(IDataReader reader)
        {
            return new TruckInfo
            {
                TruckNo = reader["TruckNo"] as string,
                Tare = reader["Tare"] == DBNull.Value ? 0 : Convert.ToInt64(reader["Tare"]),
                TareDate = reader["TareDate"] == DBNull.Value ? System.DateTime.MinValue : Convert.ToDateTime(reader["TareDate"]),
                InputCode = reader["InputCode"] as string,
                EffectDay = reader["EffectDay"] == DBNull.Value ? 0 : Convert.ToInt64(reader["EffectDay"]),
                Remark = reader["Remark"] as string,
                MaxGross = reader["MaxGross"] == DBNull.Value ? (int?)null : System.Convert.ToInt32(reader["MaxGross"]),
                MaxNet = reader["MaxNet"] == DBNull.Value ? (int?)null : System.Convert.ToInt32(reader["MaxNet"]),
                OwsCheckType = reader["OwsCheckType"] as string
            };
        }
    }
}
