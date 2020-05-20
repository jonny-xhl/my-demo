using System;
using System.Collections.Generic;
using System.Text;

namespace Jonny.AllDemo.OptionsConfig.Entity
{
    public class AppUser
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public override string ToString()
        {
            return $"Name:{Name},Age:{Age},Gender:{Gender}";
        }
    }

    public enum Gender
    {
        Unkonw,
        Male,
        Famale
    }
}
