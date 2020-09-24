using System;

namespace Jonny.AllDemo.SingleMiddleware.Services
{
    public class BaseAppService:IDisposable
    {
        public BaseAppService()
        {
            Console.WriteLine($"{this.GetType().FullName} created");
        }
        public void Dispose()
        {
            Console.WriteLine($"{this.GetType().FullName} disposed");
        }
    }
}