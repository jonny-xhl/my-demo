﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jonny.DataBase.Core
{
    public partial class PostgresDataConnection : DataConnectionBase
    {
        public override string ConnectionString
        {
            get;
            set;
        } = "User ID=root;Password=myPassword;Host=localhost;Port=5432;Database=myDataBase;Pooling=true;";

        public static bool EnableSystemSchemas { get; set; }

        public override string GetConnectionStringWithLoginInfo(string userName, string password)
        {
            NpgsqlConnectionStringBuilder builder = new NpgsqlConnectionStringBuilder(ConnectionString);

            builder.Username = userName;
            builder.Password = password;

            return builder.ToString();
        }

        private void GetDBObjectNames(string name, List<string> list)
        {
            DataTable schema = null;
            DbConnection connection = GetConnection();
            try
            {
                OpenConnection(connection);
                schema = connection.GetSchema("Tables", new string[] { null, "", null, name }); //not only public
            }
            finally
            {
                DisposeConnection(connection);
            }

            foreach (DataRow row in schema.Rows)
            {
                string schemaName = row["TABLE_SCHEMA"].ToString();
                if (!EnableSystemSchemas && (schemaName == "pg_catalog" || schemaName == "information_schema"))
                    continue;
                list.Add(schemaName + "." + "\"" + row["TABLE_NAME"].ToString() + "\"");
            }
        }

        public override string[] GetTableNames()
        {
            List<string> list = new List<string>();
            GetDBObjectNames("BASE TABLE", list);
            GetDBObjectNames("VIEW", list);
            if (list.Count == 0)
            {
                string selectCommand =
                    "SELECT n.nspname as \"Schema\", " +
                    "c.relname as \"Name\", " +
                    "CASE c.relkind WHEN 'r' THEN 'table' WHEN 'v' THEN 'view' WHEN 'i' THEN 'index' WHEN 'S' THEN 'sequence' WHEN 's' THEN 'special' WHEN 'f' THEN 'foreign table' END as \"Type\", " +
                    "pg_catalog.pg_get_userbyid(c.relowner) as \"Owner\" " +
                    "FROM pg_catalog.pg_class c " +
                         "LEFT JOIN pg_catalog.pg_namespace n ON n.oid = c.relnamespace " +
                    "WHERE c.relkind IN ('r', 'v', '') " +
                          "AND n.nspname <> 'pg_catalog' " +
                          "AND n.nspname <> 'information_schema' " +
                          "AND n.nspname !~'^pg_toast' " +
                      "AND pg_catalog.pg_table_is_visible(c.oid) " +
                    "ORDER BY 1,2; ";

                DataSet dataset = new DataSet();

                DbConnection connection = GetConnection();
                try
                {
                    OpenConnection(connection);
                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(selectCommand, connection as NpgsqlConnection);
                    adapter.Fill(dataset);

                    if (dataset.Tables.Count > 0)
                        foreach (DataRow row in dataset.Tables[0].Rows)
                        {
                            list.Add(row["Name"].ToString());
                        }
                }
                finally
                {
                    DisposeConnection(connection);
                }

            }
            return list.ToArray();
        }

        public override Type GetConnectionType()
        {
            return typeof(NpgsqlConnection);
        }
    }
}
