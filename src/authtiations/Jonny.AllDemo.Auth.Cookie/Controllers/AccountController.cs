using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Jonny.AllDemo.Auth.Cookie.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Jonny.AllDemo.Auth.Cookie.Controllers
{
    public class AccountController : Controller
    {
        public AccountController(UserRepository repository)
        {
            Repository = repository;
        }
        public UserRepository Repository { get; }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm]LoginDto login)
        {
            if (ModelState.IsValid)
            {
                if (Repository.Login(login.Account, login.Password))
                {
                    var name = Repository.GetNameByAccount(login.Account);
                    var identity = new ClaimsIdentity(new List<Claim>
                    {
                        new Claim(ClaimTypes.Name,name)
                    }, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(principal);
                    return Redirect("/");
                }
                ViewBag.Error = "用户名或密码错误";
                return View("Index");
            }
            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}