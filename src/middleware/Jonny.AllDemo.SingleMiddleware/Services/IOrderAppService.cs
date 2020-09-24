using System.Threading.Tasks;

namespace Jonny.AllDemo.SingleMiddleware.Services
{
    public interface IOrderAppService
    {
        public Task<string> GerOrderId();
    }
}