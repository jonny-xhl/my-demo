using System;
using System.Threading.Tasks;

namespace Jonny.AllDemo.SingleMiddleware.Services
{
    public class ProductAppService:BaseAppService,IProductAppService
    {
        public Task CreateAsync()
        {
            Console.WriteLine("创建成功");
            return  Task.CompletedTask;
        }
    }
}