using System;
using System.Collections.Generic;
using System.Data;
using ScaleControl.Models.Entities;
using ScaleControl.Models.Interfaces;

namespace ScaleControl.Data.Repositories
{
    /// <summary>
    /// Repository for UserList (user authentication and management) table.
    /// </summary>
    public class UserRepository : RepositoryBase
    {
        public UserRepository(IDatabaseConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

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
    }
}
