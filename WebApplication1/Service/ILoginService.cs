using WebApplication1.Models;

namespace WebApplication1.Service
{
    public interface ILoginService
    {
        public Task<ServiceResult> LoginEntry(Login login);

    }
}
