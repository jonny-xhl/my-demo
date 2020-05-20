using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jonny.AllDemo.Auth.Requirement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jonny.AllDemo.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public ICustomAuthenticationManager _manager;
        public AccountController(ICustomAuthenticationManager manager)
        {
            _manager = manager;
        }
        [HttpPost("login")]
        public ActionResult<string> Login([FromBody]UserLoginDto user)
        {
            return _manager.Authenticate(user.UserName, user.Password);
        }
    }

    public class UserLoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}