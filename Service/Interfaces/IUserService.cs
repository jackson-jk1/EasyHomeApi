using Domain.Models;
using Domain.Request.Auth;
using Domain.Utils.Result;
using Domain.ViewModels.Request;
using Domain.ViewModels.Response.Auth;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace Service.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<Result<LoginResponse>> Auth(LoginRequest login);
        Task<Result<string>> Register(UserRequest user);
        Task<Result<string>> Update(HttpContext context, UserRequest user);
        Task<Result<string>> UpdatePassword(HttpContext context, PasswordRequest pass);
        Task<Result<string>> Recover(string email);
        Task<Result<UserModel>> GetById(int id);
    }
}
