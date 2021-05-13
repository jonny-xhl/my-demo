using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jonny.DataBase.Core
{
    public partial class MsSqlDataConnection : DataConnectionBase
    {
        public override string ConnectionString
        {
            get;
            set;
        } = "Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;";

        public override string GetConnectionStringWithLoginInfo(string userName, string password)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(ConnectionString);

            builder.IntegratedSecurity = false;
            builder.UserID = userName;
            builder.Password = password;
            builder.DataSource = "127.0.0.1";
            builder.InitialCatalog = "VoloDocs";

            return builder.ToString();
        }

        private void GetDBObjectNames(string name, List<string> list)
        {
            DataTable schema = null;
            DbConnection conn = GetConnection();
            try
            {
                OpenConnection(conn);
                schema = conn.GetSchema("Tables", new string[] { null, null, null, name });
            }
            finally
            {
                DisposeConnection(conn);
            }

            foreach (DataRow row in schema.Rows)
            {
                string tableName = row["TABLE_NAME"].ToString();
                string schemaName = row["TABLE_SCHEMA"].ToString();
                if (string.Compare(schemaName, "dbo") == 0)
                    list.Add(tableName);
                else
                    list.Add(schemaName + ".\"" + tableName + "\"");
            }
        }

        /// <inheritdoc/>
        public override string[] GetTableNames()
        {
            List<string> list = new List<string>();
            GetDBObjectNames("BASE TABLE", list);
            GetDBObjectNames("VIEW", list);
            return list.ToArray();
        }

        /// <inheritdoc/>
        public override Type GetConnectionType()
        {
            return typeof(SqlConnection);
        }
    }
}
