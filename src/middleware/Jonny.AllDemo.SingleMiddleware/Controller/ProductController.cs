using System.Threading.Tasks;
using Jonny.AllDemo.SingleMiddleware.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace Jonny.AllDemo.SingleMiddleware.Controller
{
    public class ProductController : Microsoft.AspNetCore.Mvc.Controller
    {
        private int time = 1;
        private readonly IHostApplicationLifetime _lifetime;

        public ProductController(IProductAppService productAppService1,
            IProductAppService productAppService2,
            IOrderAppService orderAppService1,
            IOrderAppService orderAppService2,
            ITransientTestAppService transientTestAppService1,
            ITransientTestAppService transientTestAppService2,
            IHostApplicationLifetime lifetime)
        {
            _lifetime = lifetime;
        }

        [HttpGet]
        [Route("/get")]
        public Task<string> Get()
        {
            return Task.FromResult($"第{time++}次请求成功!");
        }

        [HttpGet]
        [Route("/stop")]
        public void Stop() => _lifetime.StopApplication();
    }
}