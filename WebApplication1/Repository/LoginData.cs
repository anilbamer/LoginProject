using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WebApplication1.Data.Entities;
using WebApplication1.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


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

        public async Task<ServiceResult> Deleteinfo(int id)
        {
            try
            {
                var userToDelete = await _context.DataTables.FirstOrDefaultAsync(u => u.Id == id);
                if (userToDelete != null)
                {
                    _context.DataTables.Remove(userToDelete);
                    await _context.SaveChangesAsync();

                    return new ServiceResult
                    {
                        Message = "User deleted successfully",
                        StatusCode = StatusCodes.Status200OK,
                        Status = true
                    };
                }
                else
                {
                    return new ServiceResult
                    {
                        Message = "User not found",
                        StatusCode = StatusCodes.Status404NotFound,
                        Status = false
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return new ServiceResult
                {
                    Message = "An error occurred while deleting user",
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Status = false
                };
            }
        }

        public async  Task<ServiceResult> GetThem()
        {

            try
            {
                List<Table1> users = await _context.Table1s.ToListAsync();

                if (users != null && users.Any())
                {
                    return new ServiceResult
                    {
                        Message = "Users retrieved successfully",
                        StatusCode = StatusCodes.Status200OK,
                        ResultData = users,
                        Status = true
                    };
                }
                else
                {
                    return new ServiceResult
                    {
                        Message = "No users found",
                        StatusCode = StatusCodes.Status404NotFound,
                        Status = false
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return new ServiceResult
                {
                    Message = "An error occurred while retrieving users",
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Status = false
                };
            }
        }

        public async  Task<ServiceResult> GetUsersDetails()
        {
            try
            {
                List<DataTable> users = await _context.DataTables.ToListAsync();

                if (users != null && users.Any())
                {
                    return new ServiceResult
                    {
                        Message = "Users retrieved successfully",
                        StatusCode = StatusCodes.Status200OK,
                        ResultData = users,
                        Status = true
                    };
                }
                else
                {
                    return new ServiceResult
                    {
                        Message = "No users found",
                        StatusCode = StatusCodes.Status404NotFound,
                        Status = false
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return new ServiceResult
                {
                    Message = "An error occurred while retrieving users",
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Status = false
                };
            }
        }
    

    public async Task<ServiceResult> LoginEntry(Login login)
   {
            try
            {
                var data = new DataTable
                {
                    Firstname = login.firstName,
                    Lastname = login.lastName,
                    Email = login.email,
                    Phonenumber = login.phonenumber,
                    Id = login.id,
                };
                _context.DataTables.Add(data);
                await _context.SaveChangesAsync();
                return new ServiceResult
                {
                    Message = "Inserted Data",
                    StatusCode = StatusCodes.Status200OK,
                    ResultData = data,
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


        public async Task<ServiceResult> profile(userInfo userInfo)
        {
            try
            {
                var data = new Table1
                {
                    UserId = userInfo.Id,
                    Username = userInfo.username,
                    Password = userInfo.password
                };
                _context.Table1s.Add(data);
                await _context.SaveChangesAsync();
                return new ServiceResult
                {
                    Message = "Inserted Data",
                    StatusCode = StatusCodes.Status200OK,
                    ResultData = data,
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
