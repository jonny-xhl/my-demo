using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jonny.DataBase.Core
{
    public abstract partial class DataConnectionBase
    {
        public abstract string ConnectionString
        {
            get;
            set;
        }

        public abstract string GetConnectionStringWithLoginInfo(string userName, string password);

        public DbConnection GetConnection()
        {
            Type connectionType = GetConnectionType();
            if (connectionType != null)
            {

                DbConnection connection = GetDefaultConnection();

                if (connection != null)
                    return connection;

                // create a new connection object
                connection = Activator.CreateInstance(connectionType) as DbConnection;
                connection.ConnectionString = ConnectionString;
                return connection;
            }
            return null;
        }

        private DbConnection GetDefaultConnection()
        {
            return null;
        }

        public virtual Type GetConnectionType()
        {
            return null;
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
                list.Add(row["TABLE_NAME"].ToString());
            }
        }

        public virtual string[] GetTableNames()
        {
            List<string> list = new List<string>();
            GetDBObjectNames("TABLE", list);
            GetDBObjectNames("VIEW", list);
            return list.ToArray();
        }

        public void OpenConnection(DbConnection connection)
        {
            connection.ConnectionString = ConnectionString;
            if (connection.State == ConnectionState.Open)
                return;
            connection.Open();
        }

        public void DisposeConnection(DbConnection connection)
        {

            if (ShouldNotDispose(connection))
                return;

            if (connection != null)
                connection.Dispose();
        }

        private bool ShouldNotDispose(DbConnection connection)
        {
            return false;
        }
    }

}
