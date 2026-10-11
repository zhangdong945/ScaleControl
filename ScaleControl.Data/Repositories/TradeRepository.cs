using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ScaleControl.Models.Entities;
using ScaleControl.Models.Interfaces;

namespace ScaleControl.Data.Repositories
{
    /// <summary>
    /// Repository for Trade (weighing records) table CRUD operations.
    /// </summary>
    public class TradeRepository : RepositoryBase
    {
        public TradeRepository(IDatabaseConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public WeighingRecord GetById(long id)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Trade WHERE Id = @Id";
                    AddParameter(cmd, "@Id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapWeighingRecord(reader);
                        }
                    }
                }
            }
            return null;
        }

        public WeighingRecord GetByTicketNo(string ticketNo)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Trade WHERE TicketNo1 = @TicketNo OR TicketNo2 = @TicketNo";
                    AddParameter(cmd, "@TicketNo", ticketNo);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapWeighingRecord(reader);
                        }
                    }
                }
            }
            return null;
        }

        public long SaveWeighingRecord(WeighingRecord record)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    var sb = new StringBuilder();
                    sb.Append("INSERT INTO Trade (");
                    sb.Append("TicketNo1, TicketNo2, Station1, Station2, ScaleNo1, ScaleNo2, TruckNo, CardNo, ContractNo, ");
                    sb.Append("Product, ProductCode, Specification, Sender, Receiver, Transporter, ");
                    sb.Append("FirstDateTime, SecondDateTime, GrossDateTime, TareDateTime, ");
                    sb.Append("FirstWeight, SecondWeight, Gross, Tare, Net, ProductNet, ExceptWater, ExceptOther, ");
                    sb.Append("UserId1, UserName1, UserId2, UserName2, Bc1, Bc2, ScaleWeightFlag, SpareFlag, ");
                    sb.Append("UploadFlag, DataEditFlag, DataStatus, ManualInputFlag, ScaleMode, FinalFlag, LeftWeight, ");
                    sb.Append("TareWeightAlarmFlag, TareTimeAlarmFlag, WeightTimeAlarmFlag, AutoSaveFlag, AuthFlag, ");
                    sb.Append("Driver, BusinessNo, IdNumber, BusinessType, MaxGross, MaxNet, OwsCheckType, ReprintCount, ");
                    sb.Append("IdentifyTruckNo1, IdentifyTruckNo2, SpareStr1, SpareStr2, SpareNum1");
                    sb.Append(") VALUES (");
                    sb.Append("@TicketNo1, @TicketNo2, @Station1, @Station2, @ScaleNo1, @ScaleNo2, @TruckNo, @CardNo, @ContractNo, ");
                    sb.Append("@Product, @ProductCode, @Specification, @Sender, @Receiver, @Transporter, ");
                    sb.Append("@FirstDateTime, @SecondDateTime, @GrossDateTime, @TareDateTime, ");
                    sb.Append("@FirstWeight, @SecondWeight, @Gross, @Tare, @Net, @ProductNet, @ExceptWater, @ExceptOther, ");
                    sb.Append("@UserId1, @UserName1, @UserId2, @UserName2, @Bc1, @Bc2, @ScaleWeightFlag, @SpareFlag, ");
                    sb.Append("@UploadFlag, @DataEditFlag, @DataStatus, @ManualInputFlag, @ScaleMode, @FinalFlag, @LeftWeight, ");
                    sb.Append("@TareWeightAlarmFlag, @TareTimeAlarmFlag, @WeightTimeAlarmFlag, @AutoSaveFlag, @AuthFlag, ");
                    sb.Append("@Driver, BusinessNo, @IdNumber, BusinessType, @MaxGross, @MaxNet, @OwsCheckType, @ReprintCount, ");
                    sb.Append("@IdentifyTruckNo1, @IdentifyTruckNo2, @SpareStr1, @SpareStr2, @SpareNum1");
                    sb.Append(")");

                    cmd.CommandText = sb.ToString();
                    AddWeighingRecordParameters(cmd, record);
                    cmd.ExecuteNonQuery();

                    // Retrieve the auto-generated Id
                    cmd.CommandText = "SELECT @@IDENTITY";
                    cmd.Parameters.Clear();
                    var result = cmd.ExecuteScalar();
                    return Convert.ToInt64(result);
                }
            }
        }

        public void UpdateWeighingRecord(WeighingRecord record)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    var sb = new StringBuilder();
                    sb.Append("UPDATE Trade SET ");
                    sb.Append("TicketNo1 = @TicketNo1, TicketNo2 = @TicketNo2, ");
                    sb.Append("Station1 = @Station1, Station2 = @Station2, ScaleNo1 = @ScaleNo1, ScaleNo2 = @ScaleNo2, ");
                    sb.Append("TruckNo = @TruckNo, CardNo = @CardNo, ContractNo = @ContractNo, ");
                    sb.Append("Product = @Product, ProductCode = @ProductCode, Specification = @Specification, ");
                    sb.Append("Sender = @Sender, Receiver = @Receiver, Transporter = @Transporter, ");
                    sb.Append("FirstDateTime = @FirstDateTime, SecondDateTime = @SecondDateTime, ");
                    sb.Append("GrossDateTime = @GrossDateTime, TareDateTime = @TareDateTime, ");
                    sb.Append("FirstWeight = @FirstWeight, SecondWeight = @SecondWeight, ");
                    sb.Append("Gross = @Gross, Tare = @Tare, Net = @Net, ");
                    sb.Append("ProductNet = @ProductNet, ExceptWater = @ExceptWater, ExceptOther = @ExceptOther, ");
                    sb.Append("UserId1 = @UserId1, UserName1 = @UserName1, UserId2 = @UserId2, UserName2 = @UserName2, ");
                    sb.Append("Bc1 = @Bc1, Bc2 = @Bc2, ScaleWeightFlag = @ScaleWeightFlag, SpareFlag = @SpareFlag, ");
                    sb.Append("UploadFlag = @UploadFlag, DataEditFlag = @DataEditFlag, DataStatus = @DataStatus, ");
                    sb.Append("ManualInputFlag = @ManualInputFlag, ScaleMode = @ScaleMode, FinalFlag = @FinalFlag, ");
                    sb.Append("LeftWeight = @LeftWeight, TareWeightAlarmFlag = @TareWeightAlarmFlag, ");
                    sb.Append("TareTimeAlarmFlag = @TareTimeAlarmFlag, WeightTimeAlarmFlag = @WeightTimeAlarmFlag, ");
                    sb.Append("AutoSaveFlag = @AutoSaveFlag, AuthFlag = @AuthFlag, ");
                    sb.Append("Driver = @Driver, BusinessNo = @BusinessNo, IdNumber = @IdNumber, BusinessType = @BusinessType, ");
                    sb.Append("MaxGross = @MaxGross, MaxNet = @MaxNet, OwsCheckType = @OwsCheckType, ");
                    sb.Append("ReprintCount = @ReprintCount, IdentifyTruckNo1 = @IdentifyTruckNo1, IdentifyTruckNo2 = @IdentifyTruckNo2, ");
                    sb.Append("SpareStr1 = @SpareStr1, SpareStr2 = @SpareStr2, SpareNum1 = @SpareNum1 ");
                    sb.Append("WHERE Id = @Id");

                    cmd.CommandText = sb.ToString();
                    AddWeighingRecordParameters(cmd, record);
                    AddParameter(cmd, "@Id", record.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteWeighingRecord(long id)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Trade WHERE Id = @Id";
                    AddParameter(cmd, "@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<WeighingRecord> QueryRecords(WeighingQueryCriteria criteria)
        {
            var results = new List<WeighingRecord>();
            using (var connection = CreateConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    var sb = new StringBuilder("SELECT * FROM Trade WHERE 1=1");
                    BuildWhereClause(sb, cmd, criteria);

                    cmd.CommandText = sb.ToString();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add(MapWeighingRecord(reader));
                        }
                    }
                }
            }
            return results;
        }

        public WeighingRecord GetTempRecordByTruckNo(string truckNo)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT TOP 1 * FROM Trade WHERE TruckNo = @TruckNo AND FinalFlag = '0' ORDER BY FirstDateTime DESC";
                    AddParameter(cmd, "@TruckNo", truckNo);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapWeighingRecord(reader);
                        }
                    }
                }
            }
            return null;
        }

        #region Private Helper Methods

        private void BuildWhereClause(StringBuilder sb, IDbCommand cmd, WeighingQueryCriteria criteria)
        {
            if (criteria == null) return;

            if (criteria.StartTime.HasValue)
            {
                sb.Append(" AND FirstDateTime >= @StartTime");
                AddParameter(cmd, "@StartTime", criteria.StartTime.Value);
            }

            if (criteria.EndTime.HasValue)
            {
                sb.Append(" AND FirstDateTime <= @EndTime");
                AddParameter(cmd, "@EndTime", criteria.EndTime.Value);
            }

            if (!string.IsNullOrEmpty(criteria.DataType))
            {
                sb.Append(" AND DataStatus = @DataType");
                AddParameter(cmd, "@DataType", criteria.DataType);
            }

            if (criteria.FieldConditions != null)
            {
                foreach (var condition in criteria.FieldConditions)
                {
                    if (string.IsNullOrEmpty(condition.FieldName) || string.IsNullOrEmpty(condition.Operator))
                        continue;

                    string paramName = "@" + condition.FieldName.Replace(" ", "_");
                    switch (condition.Operator.ToUpper())
                    {
                        case "LIKE":
                            sb.AppendFormat(" AND {0} LIKE {1}", condition.FieldName, paramName);
                            AddParameter(cmd, paramName, "%" + condition.Value + "%");
                            break;
                        case "=":
                        case ">":
                        case "<":
                        case ">=":
                        case "<=":
                        case "<>":
                            sb.AppendFormat(" AND {0} {1} {2}", condition.FieldName, condition.Operator, paramName);
                            AddParameter(cmd, paramName, condition.Value);
                            break;
                        default:
                            sb.AppendFormat(" AND {0} = {1}", condition.FieldName, paramName);
                            AddParameter(cmd, paramName, condition.Value);
                            break;
                    }
                }
            }
        }

        private WeighingRecord MapWeighingRecord(IDataReader reader)
        {
            return new WeighingRecord
            {
                Id = Convert.ToInt64(reader["Id"]),
                TicketNo1 = reader["TicketNo1"] as string,
                TicketNo2 = reader["TicketNo2"] as string,
                Station1 = reader["Station1"] as string,
                Station2 = reader["Station2"] as string,
                ScaleNo1 = reader["ScaleNo1"] as string,
                ScaleNo2 = reader["ScaleNo2"] as string,
                TruckNo = reader["TruckNo"] as string,
                CardNo = reader["CardNo"] as string,
                ContractNo = reader["ContractNo"] as string,
                Product = reader["Product"] as string,
                ProductCode = reader["ProductCode"] as string,
                Specification = reader["Specification"] as string,
                Sender = reader["Sender"] as string,
                Receiver = reader["Receiver"] as string,
                Transporter = reader["Transporter"] as string,
                FirstDateTime = reader["FirstDateTime"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FirstDateTime"]),
                SecondDateTime = reader["SecondDateTime"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["SecondDateTime"]),
                GrossDateTime = reader["GrossDateTime"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["GrossDateTime"]),
                TareDateTime = reader["TareDateTime"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["TareDateTime"]),
                FirstWeight = reader["FirstWeight"] == DBNull.Value ? (long?)null : Convert.ToInt64(reader["FirstWeight"]),
                SecondWeight = reader["SecondWeight"] == DBNull.Value ? (long?)null : Convert.ToInt64(reader["SecondWeight"]),
                Gross = reader["Gross"] == DBNull.Value ? (long?)null : Convert.ToInt64(reader["Gross"]),
                Tare = reader["Tare"] == DBNull.Value ? (long?)null : Convert.ToInt64(reader["Tare"]),
                Net = reader["Net"] == DBNull.Value ? (long?)null : Convert.ToInt64(reader["Net"]),
                ProductNet = reader["ProductNet"] == DBNull.Value ? 0m : Convert.ToDecimal(reader["ProductNet"]),
                ExceptWater = reader["ExceptWater"] == DBNull.Value ? 0m : Convert.ToDecimal(reader["ExceptWater"]),
                ExceptOther = reader["ExceptOther"] == DBNull.Value ? 0m : Convert.ToDecimal(reader["ExceptOther"]),
                UserId1 = reader["UserId1"] as string,
                UserName1 = reader["UserName1"] as string,
                UserId2 = reader["UserId2"] as string,
                UserName2 = reader["UserName2"] as string,
                Bc1 = reader["Bc1"] as string,
                Bc2 = reader["Bc2"] as string,
                ScaleWeightFlag = reader["ScaleWeightFlag"] as string,
                SpareFlag = reader["SpareFlag"] as string,
                UploadFlag = reader["UploadFlag"] as string ?? "0",
                DataEditFlag = reader["DataEditFlag"] as string ?? "0",
                DataStatus = reader["DataStatus"] as string ?? "1",
                ManualInputFlag = reader["ManualInputFlag"] as string ?? "0",
                ScaleMode = reader["ScaleMode"] as string,
                FinalFlag = reader["FinalFlag"] as string ?? "0",
                LeftWeight = reader["LeftWeight"] == DBNull.Value ? (long?)null : Convert.ToInt64(reader["LeftWeight"]),
                TareWeightAlarmFlag = reader["TareWeightAlarmFlag"] as string ?? "0",
                TareTimeAlarmFlag = reader["TareTimeAlarmFlag"] as string ?? "0",
                WeightTimeAlarmFlag = reader["WeightTimeAlarmFlag"] as string ?? "0",
                AutoSaveFlag = reader["AutoSaveFlag"] as string ?? "0",
                AuthFlag = reader["AuthFlag"] as string ?? "0",
                Driver = reader["Driver"] as string,
                BusinessNo = reader["BusinessNo"] as string,
                IdNumber = reader["IdNumber"] as string,
                BusinessType = reader["BusinessType"] as string,
                MaxGross = reader["MaxGross"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["MaxGross"]),
                MaxNet = reader["MaxNet"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["MaxNet"]),
                OwsCheckType = reader["OwsCheckType"] as string,
                ReprintCount = reader["ReprintCount"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ReprintCount"]),
                IdentifyTruckNo1 = reader["IdentifyTruckNo1"] as string,
                IdentifyTruckNo2 = reader["IdentifyTruckNo2"] as string,
                SpareStr1 = reader["SpareStr1"] as string,
                SpareStr2 = reader["SpareStr2"] as string,
                SpareNum1 = reader["SpareNum1"] == DBNull.Value ? 0m : Convert.ToDecimal(reader["SpareNum1"])
            };
        }

        private void AddWeighingRecordParameters(IDbCommand cmd, WeighingRecord record)
        {
            AddParameter(cmd, "@TicketNo1", record.TicketNo1);
            AddParameter(cmd, "@TicketNo2", record.TicketNo2);
            AddParameter(cmd, "@Station1", record.Station1);
            AddParameter(cmd, "@Station2", record.Station2);
            AddParameter(cmd, "@ScaleNo1", record.ScaleNo1);
            AddParameter(cmd, "@ScaleNo2", record.ScaleNo2);
            AddParameter(cmd, "@TruckNo", record.TruckNo);
            AddParameter(cmd, "@CardNo", record.CardNo);
            AddParameter(cmd, "@ContractNo", record.ContractNo);
            AddParameter(cmd, "@Product", record.Product);
            AddParameter(cmd, "@ProductCode", record.ProductCode);
            AddParameter(cmd, "@Specification", record.Specification);
            AddParameter(cmd, "@Sender", record.Sender);
            AddParameter(cmd, "@Receiver", record.Receiver);
            AddParameter(cmd, "@Transporter", record.Transporter);
            AddParameter(cmd, "@FirstDateTime", (object)record.FirstDateTime ?? DBNull.Value);
            AddParameter(cmd, "@SecondDateTime", (object)record.SecondDateTime ?? DBNull.Value);
            AddParameter(cmd, "@GrossDateTime", (object)record.GrossDateTime ?? DBNull.Value);
            AddParameter(cmd, "@TareDateTime", (object)record.TareDateTime ?? DBNull.Value);
            AddParameter(cmd, "@FirstWeight", (object)record.FirstWeight ?? DBNull.Value);
            AddParameter(cmd, "@SecondWeight", (object)record.SecondWeight ?? DBNull.Value);
            AddParameter(cmd, "@Gross", (object)record.Gross ?? DBNull.Value);
            AddParameter(cmd, "@Tare", (object)record.Tare ?? DBNull.Value);
            AddParameter(cmd, "@Net", (object)record.Net ?? DBNull.Value);
            AddParameter(cmd, "@ProductNet", record.ProductNet);
            AddParameter(cmd, "@ExceptWater", record.ExceptWater);
            AddParameter(cmd, "@ExceptOther", record.ExceptOther);
            AddParameter(cmd, "@UserId1", record.UserId1);
            AddParameter(cmd, "@UserName1", record.UserName1);
            AddParameter(cmd, "@UserId2", record.UserId2);
            AddParameter(cmd, "@UserName2", record.UserName2);
            AddParameter(cmd, "@Bc1", record.Bc1);
            AddParameter(cmd, "@Bc2", record.Bc2);
            AddParameter(cmd, "@ScaleWeightFlag", record.ScaleWeightFlag);
            AddParameter(cmd, "@SpareFlag", record.SpareFlag);
            AddParameter(cmd, "@UploadFlag", record.UploadFlag ?? "0");
            AddParameter(cmd, "@DataEditFlag", record.DataEditFlag ?? "0");
            AddParameter(cmd, "@DataStatus", record.DataStatus ?? "1");
            AddParameter(cmd, "@ManualInputFlag", record.ManualInputFlag ?? "0");
            AddParameter(cmd, "@ScaleMode", record.ScaleMode);
            AddParameter(cmd, "@FinalFlag", record.FinalFlag ?? "0");
            AddParameter(cmd, "@LeftWeight", (object)record.LeftWeight ?? DBNull.Value);
            AddParameter(cmd, "@TareWeightAlarmFlag", record.TareWeightAlarmFlag ?? "0");
            AddParameter(cmd, "@TareTimeAlarmFlag", record.TareTimeAlarmFlag ?? "0");
            AddParameter(cmd, "@WeightTimeAlarmFlag", record.WeightTimeAlarmFlag ?? "0");
            AddParameter(cmd, "@AutoSaveFlag", record.AutoSaveFlag ?? "0");
            AddParameter(cmd, "@AuthFlag", record.AuthFlag ?? "0");
            AddParameter(cmd, "@Driver", record.Driver);
            AddParameter(cmd, "@BusinessNo", record.BusinessNo);
            AddParameter(cmd, "@IdNumber", record.IdNumber);
            AddParameter(cmd, "@BusinessType", record.BusinessType);
            AddParameter(cmd, "@MaxGross", (object)record.MaxGross ?? DBNull.Value);
            AddParameter(cmd, "@MaxNet", (object)record.MaxNet ?? DBNull.Value);
            AddParameter(cmd, "@OwsCheckType", record.OwsCheckType);
            AddParameter(cmd, "@ReprintCount", record.ReprintCount);
            AddParameter(cmd, "@IdentifyTruckNo1", record.IdentifyTruckNo1);
            AddParameter(cmd, "@IdentifyTruckNo2", record.IdentifyTruckNo2);
            AddParameter(cmd, "@SpareStr1", record.SpareStr1);
            AddParameter(cmd, "@SpareStr2", record.SpareStr2);
            AddParameter(cmd, "@SpareNum1", record.SpareNum1);
        }

        #endregion
    }
}
