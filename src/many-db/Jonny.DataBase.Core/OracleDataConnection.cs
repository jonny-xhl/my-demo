using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jonny.DataBase.Core
{
    public partial class OracleDataConnection : DataConnectionBase
    {
        public override string ConnectionString
        {
            get;
            set;
        } = "Data Source=MyOracleDB;User Id=myUsername;Password=myPassword;";

        public override string GetConnectionStringWithLoginInfo(string userName, string password)
        {
            OracleConnectionStringBuilder builder = new OracleConnectionStringBuilder(ConnectionString);

            builder.UserID = userName;
            builder.Password = password;
            // 设置Tns的地址
            builder.TnsAdmin = @"D:\Program Files\instantclient_11_2\network\admin";
            builder.DataSource = "helowin";

            return builder.ToString();
        }

        private void GetDBObjectNames(string name, string columnName, List<string> list)
        {
            DataTable schema = null;
            DbConnection connection = GetConnection();
            try
            {
                OpenConnection(connection);
                OracleConnectionStringBuilder builder = new OracleConnectionStringBuilder(connection.ConnectionString);
                schema = connection.GetSchema(name, new string[] { builder.UserID.ToUpper(), null });
            }
            finally
            {
                DisposeConnection(connection);
            }

            foreach (DataRow row in schema.Rows)
            {
                string tableName = row[columnName].ToString();
                string schemaName = row["OWNER"].ToString();
                if (string.Compare(schemaName, "SYSTEM") == 0)
                    list.Add(tableName);
                else
                    list.Add(schemaName + ".\"" + tableName + "\"");
            }
        }

        public override string[] GetTableNames()
        {
            List<string> list = new List<string>();
            GetDBObjectNames("Tables", "TABLE_NAME", list);
            GetDBObjectNames("Views", "VIEW_NAME", list);
            return list.ToArray();
        }

        public override Type GetConnectionType()
        {
            return typeof(OracleConnection);
        }
    }
}
