using System;
using System.Collections.Generic;
using System.Data;
using ScaleControl.Models.Entities;
using ScaleControl.Models.Interfaces;

namespace ScaleControl.Data.Repositories
{
    /// <summary>
    /// Repository for UserGroup and UserRoleCtrl (role and permission management) tables.
    /// </summary>
    public class RoleRepository : RepositoryBase
    {
        public RoleRepository(IDatabaseConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

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
                                GroupId = System.Convert.ToInt32(reader["GroupId"]),
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
                                GroupId = System.Convert.ToInt32(reader["GroupId"]),
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
                                GroupId = System.Convert.ToInt32(reader["GroupId"]),
                                ModelId = System.Convert.ToInt32(reader["ModelId"]),
                                ModelChnName = reader["ModelChnName"] as string,
                                Search = reader["Search"] == DBNull.Value ? false : System.Convert.ToBoolean(reader["Search"]),
                                Edit = reader["Edit"] == DBNull.Value ? false : System.Convert.ToBoolean(reader["Edit"]),
                                Other1 = reader["Other1"] == DBNull.Value ? false : System.Convert.ToBoolean(reader["Other1"]),
                                Other2 = reader["Other2"] == DBNull.Value ? false : System.Convert.ToBoolean(reader["Other2"])
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
    }
}
