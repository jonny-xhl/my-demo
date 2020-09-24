using System.Threading.Tasks;

namespace Jonny.AllDemo.SingleMiddleware.Services
{
    public class OrderAppService:BaseAppService,IOrderAppService
    {
        public Task<string> GerOrderId()
        {
            return Task.FromResult("123");
        }
    }
}