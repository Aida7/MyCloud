using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Common;

namespace MyСloud
{
    public class SqlConncetionHelper
    {
        public static DbConnection Connection
        {
            get
            {
               DbProviderFactory providerFactory = DbProviderFactories.GetFactory(ConfigurationManager
                                            .ConnectionStrings["MyСloud"].ProviderName);
                DbConnection connection = providerFactory.CreateConnection();

                connection.ConnectionString = ConfigurationManager.ConnectionStrings["MyСloud"].ConnectionString;
                return connection;
            }
        }
        public static bool ExecuteCommands(params DbCommand[] commands)
        {
            using (DbConnection connection = Connection)
            {
                connection.Open();

                DbTransaction transaction = connection.BeginTransaction();

                try
                {
                    foreach (var command in commands)
                    {
                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return true;
                }
                catch (DbException ex)
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

    }
}
