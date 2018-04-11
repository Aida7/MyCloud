using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Configuration;

namespace MyСloud
{
   public class FileService
   {
        public void CreateFiles(Files files)
        {
            DbCommand command = SqlConncetionHelper.Connection.CreateCommand();

            DbParameter formatParametr = command.CreateParameter();
            formatParametr.DbType = System.Data.DbType.String;
            formatParametr.IsNullable = false;
            formatParametr.ParameterName = "@Format";
            formatParametr.Value = files.Format;

            DbParameter nameParametr = command.CreateParameter();
            nameParametr.DbType = System.Data.DbType.String;
            nameParametr.IsNullable = false;
            nameParametr.ParameterName = "@Name";
            nameParametr.Value = files.Name;

            DbParameter wayParametr = command.CreateParameter();
            wayParametr.DbType = System.Data.DbType.String;
            wayParametr.IsNullable = false;
            wayParametr.ParameterName = "@Way";
            wayParametr.Value = files.Way;

            DbParameter userIdParametr = command.CreateParameter();
            userIdParametr.DbType = System.Data.DbType.Int32;
            userIdParametr.IsNullable = false;
            userIdParametr.ParameterName = "@userId ";
            userIdParametr.Value = files.UserId;

            command.Parameters.AddRange(new DbParameter[] { formatParametr, nameParametr, wayParametr });
            command.CommandText = @"INSERT INTO [dbo].[Files]
           ([format ],[Name],[Way],[user_id]) VALUES (@Format,@Name,@Way,@userId)";

            SqlConncetionHelper.ExecuteCommands(command);
        }
        public List<Files> SelectAllFiles()
        {
            List<Files> files = new List<Files>();

            DbCommand command = SqlConncetionHelper.Connection.CreateCommand();
            command.CommandText = "select * from files";

            DbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                files.Add(
                    new Files
                    {
                        Id = (int)reader["id"],
                        Format = reader["nickname"].ToString(),
                        Name = reader["password"].ToString(),
                        Way = reader["way"].ToString(),
                        UserId =(int)reader["user_id "],
                    });
            }

            return files;
        }
}
} 

