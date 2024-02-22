using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public interface ILogin
    {
        Task<ServiceResult> LoginEntry(Login login);
    }
}
