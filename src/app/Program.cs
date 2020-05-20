using System;
using System.Collections.Generic;
using System.Linq;

namespace myapp
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<User>()
            {
                new User("jonny",25),
                new User("admin",25),
                new User("向洪林",25),
                new User("xhl",25),
            };
            foreach (var item in list)
            {
                Console.WriteLine("开始：" + item.name);
            }
            var temp = list.Where(u => u.name == "jonny").FirstOrDefault();
            temp.name = "alibaba";
            foreach (var item in list)
            {
                Console.WriteLine("结束：" + item.name);
            }
            Console.ReadLine();
        }
    }

    internal class User
    {
        public User(string n, int a)
        {
            name = n;
            age = a;
        }
        public string name { get; set; }

        public int age { get; set; }
    }
}
