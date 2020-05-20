//using Microsoft.Extensions.Options;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Text;

//namespace Jonny.AllDemo.Dapper
//{
//    public interface ICustomDapperContext
//    {

//        void Insert(string sql);

//    }
//    public class CustomDapperContext : ICustomDapperContext
//    {
//        DapperContext _dapperContext;
//        public CustomDapperContext(DapperContext dapperContext)
//        {
//            _dapperContext = dapperContext;
//        }
//        public void Insert(string sql)
//        {
//            _dapperContext.insertTest(sql);
//        }
//    }
//    public class DapperContext
//    {
//        DapperOptions _dapperOptions;
//        IDataProvider _dataProvider;
//        public DapperContext(IOptions<DapperOptions> options, IDataProvider dataProvider)
//        {
//            _dapperOptions = options.Value;
//            _dataProvider = dataProvider;
//        }

//        private IDbConnection CreateConnection(bool ensureClose = true)
//        {

//            var conn = _dataProvider.CreateConnection();
//            conn.ConnectionString = _dapperOptions.ConnectionString;
//            conn.Open();

//            return conn;
//        }
//        private IDbConnection _connection;
//        private IDbConnection Connection
//        {
//            get
//            {
//                if (_connection == null || _connection.State != ConnectionState.Open)
//                {
//                    _connection = CreateConnection();
//                }

//                return _connection;
//            }
//        }

//        public void insertTest(string sql)
//        {


//            var conn = Connection;
//            try
//            {
//                conn.Execute(sql);
//            }

//            finally
//            {
//                if (_connection != null)
//                {
//                    _connection.Close();
//                    _connection = null;
//                }
//            }


//        }
//    }
//}
