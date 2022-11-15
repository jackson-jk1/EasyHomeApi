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
        Task<Result<GenericResponse>> Register(UserRequest user);
        Task<Result<GenericResponse>> Update(HttpContext context, UserRequest user);
        Task<Result<GenericResponse>> UpdatePassword(HttpContext context, PasswordRequest pass);
        Task<Result<GenericResponse>> Recover(string email);
        Task<Result<UserModel>> GetByToken(HttpContext context);
        Task<Result<UserModel>> GetById(int id);
    }
}
