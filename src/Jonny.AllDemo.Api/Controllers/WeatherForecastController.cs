using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Jonny.AllDemo.Api.Controllers
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
        private readonly IConfiguration _configuration;
        private TestConfig _test;
        public WeatherForecastController(ILogger<WeatherForecastController> logger
            , IConfiguration configuration
            , IOptions<TestConfig> options)
        {
            _logger = logger;
            _configuration = configuration;
            _test = options.Value;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            //var rng = new Random();
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = rng.Next(-20, 55),
            //    Summary = Summaries[rng.Next(Summaries.Length)]
            //})
            //.ToArray();
            var test = _configuration.GetSection("test");
            var name= test["name"];
            return name;
        }

        [HttpGet("JetBrainsAnnotationsNotNull")]
        public ActionResult<string> GetNotNull([NotNull]string name)
        {
            var jwa = new JetBrainsAnnotations();
            var len = jwa.Length(null);
            return len;
        }
    }
}
