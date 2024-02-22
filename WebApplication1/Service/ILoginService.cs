using WebApplication1.Models;

namespace WebApplication1.Service
{
    public interface ILoginService
    {
        Task<ServiceResult> LoginEntry(Login login);
        Task<ServiceResult> Deleteinfo(int id);
        Task<ServiceResult> GetUsersDetails();
        Task<ServiceResult> profile(userInfo userInfo);
        Task<ServiceResult> GetThem();

    }
}
