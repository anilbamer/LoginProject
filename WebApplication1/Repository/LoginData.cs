using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WebApplication1.Data.Entities;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class LoginData : ILogin
    {
        private readonly LoginDbContext _context;
        private readonly ServiceResult _serviceResult;

        public LoginData(LoginDbContext context, ServiceResult serviceResult)
        {
            _context = context;
            _serviceResult = serviceResult;
        }

        public async Task<ServiceResult> LoginEntry(Login login)
        {
            try
            {
                var signIn = new TableDatainfo
                {
                   
                    Username = login.username,
                    Password = login.password,
                    Id = login.id,
                };

                _context.TableDatainfos.Add(signIn);
                await _context.SaveChangesAsync();

                return new ServiceResult
                {
                    Message = "Inserted Data",
                    StatusCode = StatusCodes.Status200OK,
                    ResultData = signIn,
                    Status = true
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
                return new ServiceResult
                {
                    Message = "An error occurred while processing your request.",
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Status = false
                };
            }
        }
    }
}
