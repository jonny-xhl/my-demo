using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Jonny.AllDemo.Auth.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("role")]
        [Authorize(Roles = "admin")]
        public IEnumerable<Claim> GetRole()
        {
            return HttpContext.User.FindAll(c => c.Type == ClaimTypes.Role);
        }
        

        [Authorize("RequimentManage")]
        [HttpGet("roleRequiment")]
        public IEnumerable<Claim> GetRequiment()
        {
            return HttpContext.User.FindAll(c => c.Type == ClaimTypes.Email);
        }

        [Authorize("CliamManage")]
        [HttpGet("roleClaims")]
        public IEnumerable<Claim> GetClaims()
        {
            return HttpContext.User.FindAll(c => c.Type == "ManageId");
        }
    }
}
