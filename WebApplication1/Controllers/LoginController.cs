using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Service;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        [Route("LoginPage")]
        public async Task<IActionResult> LoginEntry(Login login)
        {
           var response = await _loginService.LoginEntry(login);
            return Ok(response);
        }
        [HttpDelete]
        [Route("DeleteUserInfo")]
        public async Task<IActionResult> Deleteinfo(int id)
        {
            var res = await _loginService.Deleteinfo(id);
            return Ok(res);
        }
        [HttpGet]
        [Route("UserInformations")]
        public async Task<IActionResult> GetUsersDetails()
        {
            var response = await _loginService.GetUsersDetails();
            return Ok(response);
        }
        [HttpPost]
        [Route("infouser")]
        public async Task<IActionResult> profile(userInfo userInfo)
        {
            var res = await _loginService.profile(userInfo);    
            return Ok(res);
        }
        [HttpGet]
        [Route("GetDetails")]
        public async Task<IActionResult> GetThem()
        {
            var data = await _loginService.GetThem();
            return Ok(data);
        }
    }
}
