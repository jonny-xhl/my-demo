using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Jonny.AllDemo.Auth.Cookie.Models;
using Microsoft.AspNetCore.Authentication;

namespace Jonny.AllDemo.Auth.Cookie.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            //访问主页的时候进行判断是否登录
            if (HttpContext.User?.Identity?.IsAuthenticated == true)
            {
                //用于查看用户信息
                var identity = HttpContext.User;
                return View(new UserModel(HttpContext.User.Identity.Name));
            }
            await HttpContext.ChallengeAsync();
            return Redirect("/Account");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
