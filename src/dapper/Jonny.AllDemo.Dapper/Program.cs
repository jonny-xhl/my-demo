using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Data.SqlClient;
using System.IO;

namespace Jonny.AllDemo.Dapper
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var str = "Data Source=(localdb)\\MSSQLLocalDB;Database=TestEfCore;Trusted_Connection=True;";
            using (var conn=new SqlConnection(str))
            {
                var p = new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "王尼玛的小米手机",
                    Describle = "给王尼玛测试GUID插入"
                };
                var res=conn.Execute($"INSERT INTO Product(Id,Name,Describle) VALUES(@Id,@Name,@Describle)", p);
            }
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureHostConfiguration(c=>
                {
                    c.SetBasePath(Environment.CurrentDirectory);
                    c.AddJsonFile("appsetting.json",false,true);                    
                })
            .ConfigureServices(c=>
            {
                //c.AddDapperContext(dapperoptions =>
                //{
                //    dapperoptions.ConnectionString = "Data Source=192.168.0.42;Initial Catalog=NET.Core;User ID=sa;password=lym123!@#;Integrated Security=false";
                //});
            });
    }
}
