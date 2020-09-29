using System;
using System.Collections.Generic;
using System.Linq;

namespace myapp
{
    class Program
    {
        static void Main(string[] args)
        {
            // var list = new List<User>()
            // {
            //     new User("jonny",25),
            //     new User("admin",25),
            //     new User("向洪林",25),
            //     new User("xhl",25),
            // };
            // var s=list.Union(new List<User> { new User("x",2) }).ToList();
            // //foreach (var item in list)
            // //{
            // //    Console.WriteLine("开始：" + item.name);
            // //}
            // //var temp = list.Where(u => u.name == "jonny").FirstOrDefault();
            // //temp.name = "alibaba";
            // foreach (var item in list)
            // {
            //     Console.WriteLine(item.name);
            // }
            while (Console.ReadKey().KeyChar=='u')
            {
                //只有被调用的时候才会被实例化
                var user = User.Instance;
            }
            Console.ReadLine();
        }
    }

    internal class User
    {
        public static readonly User Instance=new User();

        public User()
        {
            Console.WriteLine("user被实例化了!!!");
        }
        public User(string n, int a)
        {
            name = n;
            age = a;
        }
        public string name { get; set; }

        public int age { get; set; }
    }
}
