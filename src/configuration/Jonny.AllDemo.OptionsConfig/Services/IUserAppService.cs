using Jonny.AllDemo.OptionsConfig.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jonny.AllDemo.OptionsConfig.Services
{
    public interface IUserAppService
    {
        List<AppUser> GetUsers();
    }
}
