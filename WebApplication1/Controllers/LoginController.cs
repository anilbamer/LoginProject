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
    }
}
