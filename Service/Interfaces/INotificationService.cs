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
    public interface INotificationService : IDisposable
    {
        
        Task<Result<GenericResponse>> addNotification(HttpContext context, NotificationRequest not);
        void deleteNotification(HttpContext context, int NotificationId);
        void readNotification(HttpContext context);
        Task<Result<List<NotificationResponse>>> listNotifications(HttpContext context);
        Task<Result<GenericResponse>> sendInvitation(HttpContext context, int id);
        Task<Result<GenericResponse>> recuseInvitation(HttpContext httpContext, int id, int notId);
        Task<Result<GenericResponse>> verifyNotification(HttpContext httpContext);
    }
}
