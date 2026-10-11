using System;
using System.Collections.Generic;
using System.Data;
using ScaleControl.Models.Entities;
using ScaleControl.Models.Interfaces;

namespace ScaleControl.Data.Repositories
{
    /// <summary>
    /// Repository for MainPosition (UI field layout) table.
    /// </summary>
    public class FieldLayoutRepository : RepositoryBase
    {
        public FieldLayoutRepository(IDatabaseConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public List<FieldLayout> GetFieldLayouts(string weighingMode)
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
                Top = reader["Top"] == DBNull.Value ? 0 : System.Convert.ToInt32(reader["Top"]),
                Left = reader["Left"] == DBNull.Value ? 0 : System.Convert.ToInt32(reader["Left"]),
                Height = reader["Height"] == DBNull.Value ? 0 : System.Convert.ToInt32(reader["Height"]),
                Width = reader["Width"] == DBNull.Value ? 0 : System.Convert.ToInt32(reader["Width"]),
                FontName = reader["FontName"] as string,
                FontSize = reader["FontSize"] == DBNull.Value ? 0f : System.Convert.ToSingle(reader["FontSize"]),
                FontItalic = reader["FontItalic"] == DBNull.Value ? false : System.Convert.ToBoolean(reader["FontItalic"]),
                FontBold = reader["FontBold"] == DBNull.Value ? false : System.Convert.ToBoolean(reader["FontBold"]),
                BackColor = reader["BackColor"] as string,
                ForeColor = reader["ForeColor"] as string,
                LabelCaption = reader["LabelCaption"] as string,
                TabOrder = reader["TabOrder"] == DBNull.Value ? 0 : System.Convert.ToInt32(reader["TabOrder"]),
                IsVisible = reader["IsVisible"] == DBNull.Value ? true : System.Convert.ToBoolean(reader["IsVisible"]),
                IsReadOnly = reader["IsReadOnly"] == DBNull.Value ? false : System.Convert.ToBoolean(reader["IsReadOnly"]),
                IsClear = reader["IsClear"] == DBNull.Value ? false : System.Convert.ToBoolean(reader["IsClear"]),
                IsMustFill = reader["IsMustFill"] == DBNull.Value ? false : System.Convert.ToBoolean(reader["IsMustFill"]),
                IsMustExist = reader["IsMustExist"] == DBNull.Value ? false : System.Convert.ToBoolean(reader["IsMustExist"]),
                Formula = reader["Formula"] as string
            };
        }
    }
}
