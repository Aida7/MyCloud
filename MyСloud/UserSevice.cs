using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace MyСloud
{
    public class UserSevice
    {
        public void CreateUsers(Users user)
        {
            DbCommand command = SqlConncetionHelper.Connection.CreateCommand();

            DbParameter nicknameParametr = command.CreateParameter();
            nicknameParametr.DbType = System.Data.DbType.String;
            nicknameParametr.IsNullable = false;
            nicknameParametr.ParameterName = "@Nickname";
            nicknameParametr.Value = user.Nickname;

            DbParameter passwordParametr = command.CreateParameter();
            passwordParametr.DbType = System.Data.DbType.String;
            passwordParametr.IsNullable = false;
            passwordParametr.ParameterName = "@password";
            passwordParametr.Value = user.Password;

            command.Parameters.AddRange(new DbParameter[] { nicknameParametr, passwordParametr });
            command.CommandText = @"INSERT INTO [dbo].[users]
           ([nickname],[password]) VALUES (@Nickname, @password)";

            SqlConncetionHelper.ExecuteCommands(command);
        }

        public List<Users> SelectAllUsers()
        {
            List<Users> users = new List<Users>();

            DbCommand command = SqlConncetionHelper.Connection.CreateCommand();
            command.CommandText = "select * from users";

            DbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                users.Add(
                    new Users
                    {
                        Id = (int)reader["id"],
                        Nickname = reader["nickname"].ToString(),
                        Password = reader["password"].ToString(),
                    });
            }

            return users;
        }
    }
}
