using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.Linq;
using System.Text;
using ScaleControl.Models.Entities;
using ScaleControl.Models.Interfaces;

namespace ScaleControl.Data
{
    public class WeighingRepository : IWeighingRepository
    {
        private readonly IDatabaseConnectionFactory _connectionFactory;

        public WeighingRepository(IDatabaseConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
        }

        #region Private Helper Methods

        private IDbConnection CreateConnection()
        {
            return _connectionFactory.CreateConnection();
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

        private void AddParameter(IDbCommand cmd, string name, object value)
        {
            var parameter = cmd.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = value ?? DBNull.Value;
            cmd.Parameters.Add(parameter);
        }

        #endregion

        #region Weighing Records

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
                    sb.Append("@Driver, @BusinessNo, @IdNumber, @BusinessType, @MaxGross, @MaxNet, @OwsCheckType, @ReprintCount, ");
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

        #endregion

        #region Truck Management

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
                            return new TruckInfo
                            {
                                TruckNo = reader["TruckNo"] as string,
                                Tare = reader["Tare"] == DBNull.Value ? 0 : Convert.ToInt64(reader["Tare"]),
                                TareDate = reader["TareDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["TareDate"]),
                                InputCode = reader["InputCode"] as string,
                                EffectDay = reader["EffectDay"] == DBNull.Value ? 0 : Convert.ToInt64(reader["EffectDay"]),
                                Remark = reader["Remark"] as string,
                                MaxGross = reader["MaxGross"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["MaxGross"]),
                                MaxNet = reader["MaxNet"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["MaxNet"]),
                                OwsCheckType = reader["OwsCheckType"] as string
                            };
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
                            results.Add(new TruckInfo
                            {
                                TruckNo = reader["TruckNo"] as string,
                                Tare = reader["Tare"] == DBNull.Value ? 0 : Convert.ToInt64(reader["Tare"]),
                                TareDate = reader["TareDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["TareDate"]),
                                InputCode = reader["InputCode"] as string,
                                EffectDay = reader["EffectDay"] == DBNull.Value ? 0 : Convert.ToInt64(reader["EffectDay"]),
                                Remark = reader["Remark"] as string,
                                MaxGross = reader["MaxGross"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["MaxGross"]),
                                MaxNet = reader["MaxNet"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["MaxNet"]),
                                OwsCheckType = reader["OwsCheckType"] as string
                            });
                        }
                    }
                }
            }
            return results;
        }

        #endregion

        #region Product Management

        public ProductInfo GetProductByName(string name)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM ProductList WHERE ProductName = @Name";
                    AddParameter(cmd, "@Name", name);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new ProductInfo
                            {
                                Id = Convert.ToInt64(reader["Id"]),
                                ProductName = reader["ProductName"] as string,
                                Code = reader["Code"] as string,
                                InputCode = reader["InputCode"] as string,
                                Remark = reader["Remark"] as string,
                                EnableMaxNetLimit = reader["EnableMaxNetLimit"] == DBNull.Value ? false : Convert.ToBoolean(reader["EnableMaxNetLimit"]),
                                MaxNetLimit = reader["MaxNetLimit"] == DBNull.Value ? 0 : Convert.ToInt64(reader["MaxNetLimit"])
                            };
                        }
                    }
                }
            }
            return null;
        }

        public void SaveProduct(ProductInfo product)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                if (product.Id > 0)
                {
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = @"UPDATE ProductList SET ProductName = @ProductName, Code = @Code,
                            InputCode = @InputCode, Remark = @Remark, EnableMaxNetLimit = @EnableMaxNetLimit,
                            MaxNetLimit = @MaxNetLimit WHERE Id = @Id";
                        AddParameter(cmd, "@ProductName", product.ProductName);
                        AddParameter(cmd, "@Code", product.Code);
                        AddParameter(cmd, "@InputCode", product.InputCode);
                        AddParameter(cmd, "@Remark", product.Remark);
                        AddParameter(cmd, "@EnableMaxNetLimit", product.EnableMaxNetLimit);
                        AddParameter(cmd, "@MaxNetLimit", product.MaxNetLimit);
                        AddParameter(cmd, "@Id", product.Id);
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = @"INSERT INTO ProductList (ProductName, Code, InputCode, Remark, EnableMaxNetLimit, MaxNetLimit)
                            VALUES (@ProductName, @Code, @InputCode, @Remark, @EnableMaxNetLimit, @MaxNetLimit)";
                        AddParameter(cmd, "@ProductName", product.ProductName);
                        AddParameter(cmd, "@Code", product.Code);
                        AddParameter(cmd, "@InputCode", product.InputCode);
                        AddParameter(cmd, "@Remark", product.Remark);
                        AddParameter(cmd, "@EnableMaxNetLimit", product.EnableMaxNetLimit);
                        AddParameter(cmd, "@MaxNetLimit", product.MaxNetLimit);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public List<ProductInfo> GetProducts(string filter)
        {
            var results = new List<ProductInfo>();
            using (var connection = CreateConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    if (string.IsNullOrEmpty(filter))
                    {
                        cmd.CommandText = "SELECT * FROM ProductList ORDER BY ProductName";
                    }
                    else
                    {
                        cmd.CommandText = "SELECT * FROM ProductList WHERE ProductName LIKE @Filter OR Code LIKE @Filter OR InputCode LIKE @Filter ORDER BY ProductName";
                        AddParameter(cmd, "@Filter", "%" + filter + "%");
                    }
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add(new ProductInfo
                            {
                                Id = Convert.ToInt64(reader["Id"]),
                                ProductName = reader["ProductName"] as string,
                                Code = reader["Code"] as string,
                                InputCode = reader["InputCode"] as string,
                                Remark = reader["Remark"] as string,
                                EnableMaxNetLimit = reader["EnableMaxNetLimit"] == DBNull.Value ? false : Convert.ToBoolean(reader["EnableMaxNetLimit"]),
                                MaxNetLimit = reader["MaxNetLimit"] == DBNull.Value ? 0 : Convert.ToInt64(reader["MaxNetLimit"])
                            });
                        }
                    }
                }
            }
            return results;
        }

        #endregion

        #region Customer Management (Senders/Receivers)

        public void SaveSender(CustomerInfo customer)
        {
            SaveCustomer(customer, "SenderList");
        }

        public void SaveReceiver(CustomerInfo customer)
        {
            SaveCustomer(customer, "ReceiverList");
        }

        private void SaveCustomer(CustomerInfo customer, string tableName)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                if (customer.Id > 0)
                {
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = $"UPDATE {tableName} SET Name = @Name, InputCode = @InputCode, Remark = @Remark WHERE Id = @Id";
                        AddParameter(cmd, "@Name", customer.Name);
                        AddParameter(cmd, "@InputCode", customer.InputCode);
                        AddParameter(cmd, "@Remark", customer.Remark);
                        AddParameter(cmd, "@Id", customer.Id);
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = $"INSERT INTO {tableName} (Name, InputCode, Remark) VALUES (@Name, @InputCode, @Remark)";
                        AddParameter(cmd, "@Name", customer.Name);
                        AddParameter(cmd, "@InputCode", customer.InputCode);
                        AddParameter(cmd, "@Remark", customer.Remark);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public List<CustomerInfo> GetSenders(string filter)
        {
            return GetCustomers(filter, "SenderList");
        }

        public List<CustomerInfo> GetReceivers(string filter)
        {
            return GetCustomers(filter, "ReceiverList");
        }

        private List<CustomerInfo> GetCustomers(string filter, string tableName)
        {
            var results = new List<CustomerInfo>();
            using (var connection = CreateConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    if (string.IsNullOrEmpty(filter))
                    {
                        cmd.CommandText = $"SELECT * FROM {tableName} ORDER BY Name";
                    }
                    else
                    {
                        cmd.CommandText = $"SELECT * FROM {tableName} WHERE Name LIKE @Filter OR InputCode LIKE @Filter ORDER BY Name";
                        AddParameter(cmd, "@Filter", "%" + filter + "%");
                    }
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add(new CustomerInfo
                            {
                                Id = Convert.ToInt64(reader["Id"]),
                                Name = reader["Name"] as string,
                                InputCode = reader["InputCode"] as string,
                                Remark = reader["Remark"] as string
                            });
                        }
                    }
                }
            }
            return results;
        }

        #endregion

        #region User Authentication

        public UserInfo ValidateUser(string loginName, string password)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM UserList WHERE LogName = @LogName";
                    AddParameter(cmd, "@LogName", loginName);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var storedPassword = reader["Password"] as string;
                            // Simple password comparison for MVP
                            if (string.Equals(storedPassword, password, StringComparison.Ordinal))
                            {
                                return new UserInfo
                                {
                                    Id = Convert.ToInt64(reader["Id"]),
                                    UserId = reader["UserId"] as string,
                                    LogName = reader["LogName"] as string,
                                    UserName = reader["UserName"] as string,
                                    GroupName = reader["GroupName"] as string,
                                    Password = storedPassword,
                                    Remark = reader["Remark"] as string
                                };
                            }
                        }
                    }
                }
            }
            return null;
        }

        public void SaveUser(UserInfo user)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                if (user.Id > 0)
                {
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = @"UPDATE UserList SET UserId = @UserId, LogName = @LogName,
                            UserName = @UserName, GroupName = @GroupName, Password = @Password, Remark = @Remark
                            WHERE Id = @Id";
                        AddParameter(cmd, "@UserId", user.UserId);
                        AddParameter(cmd, "@LogName", user.LogName);
                        AddParameter(cmd, "@UserName", user.UserName);
                        AddParameter(cmd, "@GroupName", user.GroupName);
                        AddParameter(cmd, "@Password", user.Password);
                        AddParameter(cmd, "@Remark", user.Remark);
                        AddParameter(cmd, "@Id", user.Id);
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = @"INSERT INTO UserList (UserId, LogName, UserName, GroupName, Password, Remark)
                            VALUES (@UserId, @LogName, @UserName, @GroupName, @Password, @Remark)";
                        AddParameter(cmd, "@UserId", user.UserId);
                        AddParameter(cmd, "@LogName", user.LogName);
                        AddParameter(cmd, "@UserName", user.UserName);
                        AddParameter(cmd, "@GroupName", user.GroupName);
                        AddParameter(cmd, "@Password", user.Password);
                        AddParameter(cmd, "@Remark", user.Remark);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public void UpdatePassword(string userId, string newPassword)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "UPDATE UserList SET Password = @Password WHERE UserId = @UserId";
                    AddParameter(cmd, "@Password", newPassword);
                    AddParameter(cmd, "@UserId", userId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<UserInfo> GetUsers()
        {
            var results = new List<UserInfo>();
            using (var connection = CreateConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM UserList ORDER BY UserName";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add(new UserInfo
                            {
                                Id = Convert.ToInt64(reader["Id"]),
                                UserId = reader["UserId"] as string,
                                LogName = reader["LogName"] as string,
                                UserName = reader["UserName"] as string,
                                GroupName = reader["GroupName"] as string,
                                Password = reader["Password"] as string,
                                Remark = reader["Remark"] as string
                            });
                        }
                    }
                }
            }
            return results;
        }

        #endregion

        #region Role and Permission Management

        public List<RoleInfo> GetRoles()
        {
            var results = new List<RoleInfo>();
            using (var connection = CreateConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM UserGroup ORDER BY GroupName";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add(new RoleInfo
                            {
                                GroupId = Convert.ToInt32(reader["GroupId"]),
                                GroupName = reader["GroupName"] as string,
                                Remark = reader["Remark"] as string
                            });
                        }
                    }
                }
            }
            return results;
        }

        public RoleInfo GetRoleById(int roleId)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM UserGroup WHERE GroupId = @GroupId";
                    AddParameter(cmd, "@GroupId", roleId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new RoleInfo
                            {
                                GroupId = Convert.ToInt32(reader["GroupId"]),
                                GroupName = reader["GroupName"] as string,
                                Remark = reader["Remark"] as string
                            };
                        }
                    }
                }
            }
            return null;
        }

        public void SaveRole(RoleInfo role)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    if (role.GroupId > 0)
                    {
                        cmd.CommandText = "UPDATE UserGroup SET GroupName = @GroupName, Remark = @Remark WHERE GroupId = @GroupId";
                        AddParameter(cmd, "@GroupName", role.GroupName);
                        AddParameter(cmd, "@Remark", role.Remark);
                        AddParameter(cmd, "@GroupId", role.GroupId);
                    }
                    else
                    {
                        cmd.CommandText = "INSERT INTO UserGroup (GroupName, Remark) VALUES (@GroupName, @Remark)";
                        AddParameter(cmd, "@GroupName", role.GroupName);
                        AddParameter(cmd, "@Remark", role.Remark);
                    }
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<RolePermission> GetRolePermissions(int roleId)
        {
            var results = new List<RolePermission>();
            using (var connection = CreateConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM UserRoleCtrl WHERE GroupId = @GroupId";
                    AddParameter(cmd, "@GroupId", roleId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add(new RolePermission
                            {
                                GroupId = Convert.ToInt32(reader["GroupId"]),
                                ModelId = Convert.ToInt32(reader["ModelId"]),
                                ModelChnName = reader["ModelChnName"] as string,
                                Search = reader["Search"] == DBNull.Value ? false : Convert.ToBoolean(reader["Search"]),
                                Edit = reader["Edit"] == DBNull.Value ? false : Convert.ToBoolean(reader["Edit"]),
                                Other1 = reader["Other1"] == DBNull.Value ? false : Convert.ToBoolean(reader["Other1"]),
                                Other2 = reader["Other2"] == DBNull.Value ? false : Convert.ToBoolean(reader["Other2"])
                            });
                        }
                    }
                }
            }
            return results;
        }

        public void SaveRolePermissions(int roleId, List<RolePermission> permissions)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                // Delete existing permissions for this role
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM UserRoleCtrl WHERE GroupId = @GroupId";
                    AddParameter(cmd, "@GroupId", roleId);
                    cmd.ExecuteNonQuery();
                }

                // Insert new permissions
                foreach (var perm in permissions)
                {
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = @"INSERT INTO UserRoleCtrl (GroupId, ModelId, ModelChnName, Search, Edit, Other1, Other2)
                            VALUES (@GroupId, @ModelId, @ModelChnName, @Search, @Edit, @Other1, @Other2)";
                        AddParameter(cmd, "@GroupId", roleId);
                        AddParameter(cmd, "@ModelId", perm.ModelId);
                        AddParameter(cmd, "@ModelChnName", perm.ModelChnName);
                        AddParameter(cmd, "@Search", perm.Search);
                        AddParameter(cmd, "@Edit", perm.Edit);
                        AddParameter(cmd, "@Other1", perm.Other1);
                        AddParameter(cmd, "@Other2", perm.Other2);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        #endregion

        #region Ticket Number Generation

        public string GenerateTicketNo(string stationNo)
        {
            var today = DateTime.Now.ToString("yyyyMMdd");
            var prefix = "T" + today;

            using (var connection = CreateConnection())
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

        #endregion

        #region Logging

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

        #endregion

        #region Menu

        public List<MenuClass> GetMenuClasses()
        {
            var results = new List<MenuClass>();
            using (var connection = CreateConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM SysMenuClassList ORDER BY OrderNum";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add(new MenuClass
                            {
                                ClassId = Convert.ToInt32(reader["ClassId"]),
                                ChnText = reader["ChnText"] as string,
                                EngText = reader["EngText"] as string,
                                Order = reader["OrderNum"] == DBNull.Value ? 0 : Convert.ToInt32(reader["OrderNum"])
                            });
                        }
                    }
                }
            }
            return results;
        }

        public List<MenuItem> GetMenuItems(int classId)
        {
            var results = new List<MenuItem>();
            using (var connection = CreateConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM SysMenuList WHERE ClassId = @ClassId ORDER BY OrderNum";
                    AddParameter(cmd, "@ClassId", classId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add(new MenuItem
                            {
                                MenuId = Convert.ToInt32(reader["MenuId"]),
                                ClassId = Convert.ToInt32(reader["ClassId"]),
                                ChnText = reader["ChnText"] as string,
                                EngText = reader["EngText"] as string,
                                ImageIndex = reader["ImageIndex"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ImageIndex"]),
                                Order = reader["OrderNum"] == DBNull.Value ? 0 : Convert.ToInt32(reader["OrderNum"]),
                                CanUseFlag = reader["CanUseFlag"] == DBNull.Value ? true : Convert.ToBoolean(reader["CanUseFlag"]),
                                OperatorText = reader["OperatorText"] as string
                            });
                        }
                    }
                }
            }
            return results;
        }

        #endregion

        #region Report Management

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
                            results.Add(new ReportInfo
                            {
                                ReportId = Convert.ToInt32(reader["ReportId"]),
                                ReportName = reader["ReportName"] as string,
                                ReportCHNName = reader["ReportCHNName"] as string,
                                ReportSQL = reader["ReportSQL"] as string,
                                ReportType = reader["ReportType"] as string,
                                Root = reader["Root"] as string
                            });
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
                            return new ReportInfo
                            {
                                ReportId = Convert.ToInt32(reader["ReportId"]),
                                ReportName = reader["ReportName"] as string,
                                ReportCHNName = reader["ReportCHNName"] as string,
                                ReportSQL = reader["ReportSQL"] as string,
                                ReportType = reader["ReportType"] as string,
                                Root = reader["Root"] as string
                            };
                        }
                    }
                }
            }
            return null;
        }

        #endregion

        #region Field Layout

        public List<FieldLayout> getFieldLayouts(string weighingMode)
        {
            var results = new List<FieldLayout>();
            using (var connection = CreateConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM MainPosition WHERE ScaleMode = @ScaleMode ORDER BY TabOrder";
                    AddParameter(cmd, "@ScaleMode", weighingMode);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add(MapFieldLayout(reader));
                        }
                    }
                }
            }
            return results;
        }

        public void SaveFieldLayouts(List<FieldLayout> layouts, string weighingMode)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                // Delete existing layouts for this mode
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM MainPosition WHERE ScaleMode = @ScaleMode";
                    AddParameter(cmd, "@ScaleMode", weighingMode);
                    cmd.ExecuteNonQuery();
                }

                // Insert new layouts
                foreach (var layout in layouts)
                {
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = @"INSERT INTO MainPosition (ScaleMode, FieldName, CtrlName, Top, Left, Height, Width,
                            FontName, FontSize, FontItalic, FontBold, BackColor, ForeColor, LabelCaption, TabOrder,
                            IsVisible, IsReadOnly, IsClear, IsMustFill, IsMustExist, Formula)
                            VALUES (@ScaleMode, @FieldName, @CtrlName, @Top, @Left, @Height, @Width,
                            @FontName, @FontSize, @FontItalic, @FontBold, @BackColor, @ForeColor, @LabelCaption, @TabOrder,
                            @IsVisible, @IsReadOnly, @IsClear, @IsMustFill, @IsMustExist, @Formula)";
                        AddParameter(cmd, "@ScaleMode", weighingMode);
                        AddParameter(cmd, "@FieldName", layout.FieldName);
                        AddParameter(cmd, "@CtrlName", layout.CtrlName);
                        AddParameter(cmd, "@Top", layout.Top);
                        AddParameter(cmd, "@Left", layout.Left);
                        AddParameter(cmd, "@Height", layout.Height);
                        AddParameter(cmd, "@Width", layout.Width);
                        AddParameter(cmd, "@FontName", layout.FontName);
                        AddParameter(cmd, "@FontSize", layout.FontSize);
                        AddParameter(cmd, "@FontItalic", layout.FontItalic);
                        AddParameter(cmd, "@FontBold", layout.FontBold);
                        AddParameter(cmd, "@BackColor", layout.BackColor);
                        AddParameter(cmd, "@ForeColor", layout.ForeColor);
                        AddParameter(cmd, "@LabelCaption", layout.LabelCaption);
                        AddParameter(cmd, "@TabOrder", layout.TabOrder);
                        AddParameter(cmd, "@IsVisible", layout.IsVisible);
                        AddParameter(cmd, "@IsReadOnly", layout.IsReadOnly);
                        AddParameter(cmd, "@IsClear", layout.IsClear);
                        AddParameter(cmd, "@IsMustFill", layout.IsMustFill);
                        AddParameter(cmd, "@IsMustExist", layout.IsMustExist);
                        AddParameter(cmd, "@Formula", layout.Formula);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        private FieldLayout MapFieldLayout(IDataReader reader)
        {
            return new FieldLayout
            {
                ScaleMode = reader["ScaleMode"] as string,
                FieldName = reader["FieldName"] as string,
                CtrlName = reader["CtrlName"] as string,
                Top = reader["Top"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Top"]),
                Left = reader["Left"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Left"]),
                Height = reader["Height"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Height"]),
                Width = reader["Width"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Width"]),
                FontName = reader["FontName"] as string,
                FontSize = reader["FontSize"] == DBNull.Value ? 0f : Convert.ToSingle(reader["FontSize"]),
                FontItalic = reader["FontItalic"] == DBNull.Value ? false : Convert.ToBoolean(reader["FontItalic"]),
                FontBold = reader["FontBold"] == DBNull.Value ? false : Convert.ToBoolean(reader["FontBold"]),
                BackColor = reader["BackColor"] as string,
                ForeColor = reader["ForeColor"] as string,
                LabelCaption = reader["LabelCaption"] as string,
                TabOrder = reader["TabOrder"] == DBNull.Value ? 0 : Convert.ToInt32(reader["TabOrder"]),
                IsVisible = reader["IsVisible"] == DBNull.Value ? true : Convert.ToBoolean(reader["IsVisible"]),
                IsReadOnly = reader["IsReadOnly"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsReadOnly"]),
                IsClear = reader["IsClear"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsClear"]),
                IsMustFill = reader["IsMustFill"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsMustFill"]),
                IsMustExist = reader["IsMustExist"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsMustExist"]),
                Formula = reader["Formula"] as string
            };
        }

        #endregion
    }
}