using System;
using System.Collections.Generic;
using System.Data;
using ScaleControl.Models.Entities;
using ScaleControl.Models.Interfaces;

namespace ScaleControl.Data.Repositories
{
    /// <summary>
    /// Repository for SysMenuClassList and SysMenuList (menu management) tables.
    /// </summary>
    public class MenuRepository : RepositoryBase
    {
        public MenuRepository(IDatabaseConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

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
                                ClassId = System.Convert.ToInt32(reader["ClassId"]),
                                ChnText = reader["ChnText"] as string,
                                EngText = reader["EngText"] as string,
                                Order = reader["OrderNum"] == DBNull.Value ? 0 : System.Convert.ToInt32(reader["OrderNum"])
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
                                MenuId = System.Convert.ToInt32(reader["MenuId"]),
                                ClassId = System.Convert.ToInt32(reader["ClassId"]),
                                ChnText = reader["ChnText"] as string,
                                EngText = reader["EngText"] as string,
                                ImageIndex = reader["ImageIndex"] == DBNull.Value ? 0 : System.Convert.ToInt32(reader["ImageIndex"]),
                                Order = reader["OrderNum"] == DBNull.Value ? 0 : System.Convert.ToInt32(reader["OrderNum"]),
                                CanUseFlag = reader["CanUseFlag"] == DBNull.Value ? true : System.Convert.ToBoolean(reader["CanUseFlag"]),
                                OperatorText = reader["OperatorText"] as string
                            });
                        }
                    }
                }
            }
            return results;
        }
    }
}
