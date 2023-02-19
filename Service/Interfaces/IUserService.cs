using Domain.Models;
using Domain.Request.Auth;
using Domain.Utils.Result;
using Domain.ViewModels.Request;
using Domain.ViewModels.Response;
using Domain.ViewModels.Response.Auth;
using Domain.ViewModels.Response.Notificacoes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text;

namespace Service.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<Result<LoginResponse>> auth(LoginRequest login);
        Task<Result<GenericResponse>> register(UserRequest user);
        Task<Result<GenericResponse>> update(HttpContext context, UserRequest user);
        Task<Result<GenericResponse>> updatePassword(HttpContext context, PasswordRequest pass);
        Task<Result<GenericResponse>> recover(string email);
        Task<Result<bool>> checkImmobile(HttpContext context, int id);
        Task<Result<UserResponse>> getByToken(HttpContext context);
        Task<Result<UserResponse>> getById(int id);
        Task<Result<GenericResponse>> addFavorite(HttpContext context, int immId);
        Task<Result<GenericResponse>> removeFavorite(HttpContext context, int immId);
        Task<Result<List<ContactResponse>>> listContacts(HttpContext context);
        Task<Result<GenericResponse>> addContact(HttpContext context, int id, int notId);
        Task<Result<GenericResponse>> removeContact(HttpContext context, int id);
        Task<Result<List<UserResponse>>> getUsersByImmobile(HttpContext context, int immId);
        Task<Result<GenericResponse>> getContact(HttpContext context, int idContact);
        Task<Result<UserResponse>> getContactById(HttpContext httpContext, int contactId);
    }
}
