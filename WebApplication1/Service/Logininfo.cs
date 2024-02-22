using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Service
{
    public class Logininfo: ILoginService
    {
        private readonly ILogin _login;
        private readonly ServiceResult _serviceResult;
        public Logininfo( ServiceResult serviceResult, ILogin login)
            {
                _serviceResult = serviceResult;
                _login = login;
             }

        public async Task<ServiceResult> Deleteinfo(int id)
        {
            return await _login.Deleteinfo(id);
        }

        public async Task<ServiceResult> GetThem()
        {
            return await _login.GetThem();
        }

        public Task<ServiceResult> GetUsersDetails()
        {
            return _login.GetUsersDetails();
        }

        public async Task<ServiceResult> LoginEntry(Login login)
        {
            return await _login.LoginEntry(login);
        }

        public async Task<ServiceResult> profile(userInfo userInfo)
        {
            return await _login.profile(userInfo);
        }
    }
}
