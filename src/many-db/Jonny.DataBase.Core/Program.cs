//#r "nuget:Npgsql/3.2.7"
//#r "nuget:MySql.Data/6.10.7"
//#r "nuget:MongoDB.Driver/2.5.0"

// Framwork
//#r "nuget:Oracle.ManagedDataAccess/19.11.0"

// Net Core
//#r "nuget:Microsoft.Data.SqlClient/2.1.2"
//#r "nuget:Oracle.ManagedDataAccess.Core/2.12.0-beta3"

// <.net core 3.1使用
using System.Data.SqlClient;
// >.net core 3.1使用
using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;
using Oracle.ManagedDataAccess.Client;
using Npgsql;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using MongoDB.Bson;

namespace Jonny.DataBase.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 连接字符串测试
            DataConnectionBase ms = new MsSqlDataConnection();
            var str1 = ms.GetConnectionStringWithLoginInfo("sa", "zjcoo1129");
            ms.ConnectionString = str1;
            Console.WriteLine("MsSqlDataConnection:" + str1);

            DataConnectionBase mysql = new MySqlDataConnection();
            var str2 = mysql.GetConnectionStringWithLoginInfo("root", "123456");
            mysql.ConnectionString = str2;
            Console.WriteLine("MySqlDataConnection:" + str2);


            DataConnectionBase oracle = new OracleDataConnection();
            var str3 = oracle.GetConnectionStringWithLoginInfo("cy", "zjcoo1129");
            oracle.ConnectionString = str3;
            Console.WriteLine("OracleDataConnection:" + str3);


            DataConnectionBase pgsql = new PostgresDataConnection();
            var str4 = pgsql.GetConnectionStringWithLoginInfo("sa", "zjcoo1129");
            pgsql.ConnectionString = str4;
            Console.WriteLine("PostgresDataConnection:" + str4);


            DataConnectionBase mg = new MongoDBDataConnection();
            var str5 = mg.GetConnectionStringWithLoginInfo("root", "123456");
            mg.ConnectionString = str5;
            Console.WriteLine("MongoDBDataConnection:" + str5);
            #endregion

            #region 获取数据库对象测试
            Console.WriteLine("SqlServer TableNames");
            foreach (var tableName in ms.GetTableNames())
            {
                Console.WriteLine(tableName);
            }

            Console.WriteLine("MySql TableNames");
            foreach (var tableName in mysql.GetTableNames())
            {
                Console.WriteLine(tableName);
            }

            Console.WriteLine("Oracle TableNames");
            foreach (var tableName in oracle.GetTableNames())
            {
                Console.WriteLine(tableName);
            }

            Console.WriteLine("MongoDb TableNames");
            foreach (var tableName in mg.GetTableNames())
            {
                Console.WriteLine(tableName);
            }

            Console.WriteLine("PostGreSql TableNames");
            foreach (var tableName in pgsql.GetTableNames())
            {
                Console.WriteLine(tableName);
            }
            #endregion
        }
    }

}
