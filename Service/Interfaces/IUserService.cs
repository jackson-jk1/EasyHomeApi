using Domain.Models;
using Domain.Request.Auth;
using Domain.Utils.Result;
using Domain.ViewModels.Request;
using Domain.ViewModels.Response;
using Domain.ViewModels.Response.Auth;
using Domain.ViewModels.Response.Notificacoes;
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
        Task<Result<bool>> checkImmobile(HttpContext context, int id);
        Task<Result<UserResponse>> GetByToken(HttpContext context);
        Task<Result<UserResponse>> GetById(int id);
        Task<Result<GenericResponse>> addFavorite(HttpContext context, int immId);
        Task<Result<GenericResponse>> removeFavorite(HttpContext context, int immId);
        Task<Result<GenericResponse>> addNotification(HttpContext context, NotificationRequest not);
        void deleteNotification(HttpContext context, int NotificationId);
        void readNotification(HttpContext context);
        Task<Result<List<ContactResponse>>> listContacts(HttpContext context);
        Task<Result<List<NotificationResponse>>> listNotifications(HttpContext context);
        Task<Result<GenericResponse>> addContact(HttpContext context, int id, int notId);
        Task<Result<GenericResponse>> removeContact(HttpContext context, int id);
        Task<Result<GenericResponse>> sendInvitation(HttpContext context, int id);
        Task<Result<List<UserResponse>>> getUsersByImmobile(HttpContext context, int immId);
        Task<Result<GenericResponse>> recuseInvitation(HttpContext httpContext, int id, int notId);
    }
}
