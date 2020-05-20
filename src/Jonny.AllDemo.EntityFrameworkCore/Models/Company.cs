using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jonny.AllDemo.EntityFrameworkCore.Models
{
    public class Company
    {
        public int Id { get; set; }

        public List<Users> Users { get; set; }
    }
}
