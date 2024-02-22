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

        public async Task<ServiceResult> LoginEntry(Login login)
        {
            return await _login.LoginEntry(login);
        }
    }
}
