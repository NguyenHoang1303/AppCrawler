using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotHandlerSourceSub.Util
{
    class ConnectionHelper
    {
        private static SqlConnection _connection;
        private static string DataSource = "tcp:apparticledb.database.windows.net,1433";
        private static string UserID = "articledb";
        private static string Password = "123@123Aa";
        private static string InitialCatalog = "AppCrawlerDemoDb";
        public static SqlConnection GetConnectSql()
        {

            if (_connection == null || _connection.State == ConnectionState.Closed)
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = DataSource;
                builder.UserID = UserID;
                builder.Password = Password;
                builder.InitialCatalog = InitialCatalog;
                _connection = new SqlConnection(builder.ConnectionString);
            }
            return _connection;
        }
    }
}
