using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jonny.DataBase.Core
{
    public partial class MySqlDataConnection : DataConnectionBase
    {
        public override string ConnectionString
        {
            get;
            set;
        } = "Server=myServerAddress;Database=myDataBase;Uid=myUsername;Pwd=myPassword;";

        public override string GetConnectionStringWithLoginInfo(string userName, string password)
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder(ConnectionString);

            builder.UserID = userName;
            builder.Password = password;
            builder.Server = "192.168.3.220";
            builder.Port = 3306;
            builder.Database = "Test";
            builder.CharacterSet = "utf8";

            return builder.ToString();
        }

        private void GetDBObjectNames(string name, List<string> list)
        {
            DataTable schema = null;
            string databaseName = "";
            DbConnection connection = GetConnection();
            try
            {
                OpenConnection(connection);
                MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder(ConnectionString);
                schema = connection.GetSchema(name);
                databaseName = builder.Database;
            }
            finally
            {
                DisposeConnection(connection);
            }
            foreach (DataRow row in schema.Rows)
            {
                if (string.IsNullOrEmpty(databaseName) || string.Compare(row["TABLE_SCHEMA"].ToString(), databaseName) == 0)
                    list.Add(row["TABLE_NAME"].ToString());
            }
        }

        public override string[] GetTableNames()
        {
            List<string> list = new List<string>();
            GetDBObjectNames("Tables", list);
            GetDBObjectNames("Views", list);
            return list.ToArray();
        }

        public override Type GetConnectionType()
        {
            return typeof(MySqlConnection);
        }
    }
}
