using Jonny.AllDemo.Reflection.TestModel;
using System;
using System.Security.Cryptography;
using
     System.Text;

namespace Jonny.AllDemo.Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            //var pubs = TenantManagementPermissions.GetAll();
            var pwd = "zjcoo1129";
            var p = BitConverter.ToString(MD5.Create()
                .ComputeHash(Encoding.UTF8.GetBytes(pwd))).Replace("-", "").ToLower();
            Console.WriteLine(p);
            Console.ReadLine();
        }
    }
}
