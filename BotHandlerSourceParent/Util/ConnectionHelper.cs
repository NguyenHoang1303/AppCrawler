using System.Data;
using System.Data.SqlClient;

namespace BotHandlerSourceParent.Util
{
    class ConnectionHelper
    {
        private static SqlConnection _connection;
        private const string ConnectionString = "Data Source=NGUYENHS;Initial Catalog=ClientApp;Integrated Security=SSPI;";
        public static SqlConnection GetConnectSql()
        {
            if (_connection == null || _connection.State == ConnectionState.Closed)
            {
                _connection = new SqlConnection(
                    string.Format(ConnectionString));
            }
            return _connection;
        }
    }
}
