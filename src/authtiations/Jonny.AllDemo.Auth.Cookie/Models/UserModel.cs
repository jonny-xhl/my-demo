using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jonny.AllDemo.Auth.Cookie.Models
{
    public class UserModel
    {
        public UserModel(string name)
        {
            Name = name;
        }
        public UserModel(string name, string account,string password):this(name)
        {
            Account = account;
            Password = password;
        }
        public string Name { get; set; }

        public string Account { get; set; }

        public string Password { get; set; }
    }
    public class UserRepository
    {
        public IList<UserModel> Users()
        {
            return new List<UserModel>
            {
                new UserModel("管理员","admin","123"),
                new UserModel("医生","doctor","123"),
                new UserModel("护士","nurse","123")
            };
        }

        public bool Login(string account,string password)
        {
            return Users().Any(u => u.Account == account && u.Password == password);
        }

        public string GetNameByAccount(string account)
        {
            return Users().FirstOrDefault(u => u.Account == account)?.Name;
        }
    }
}
