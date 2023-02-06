using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Domain.Request.Auth;
using Domain.Utils.Result;
using Domain.ViewModels.Request;
using Domain.ViewModels.Response;
using Domain.ViewModels.Response.Auth;
using Domain.ViewModels.Response.Notificacoes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SendGrid;
using Service.Helpers;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Service.Services
{
    public class NotificationService : INotificationService
    {
        [Obsolete]
        private readonly IHostingEnvironment _appEnvironment;
        private readonly IMapper _mapper;
        private readonly INotificationRepository _notificationRepository;
        private readonly IUserRepository _userRepository;
        [Obsolete]
        public NotificationService(IHostingEnvironment environment, IMapper mapper, IUserRepository baseRepository, INotificationRepository notificationRepository)
        {
            _appEnvironment = environment;
            _mapper = mapper;
            _userRepository = baseRepository;
            _notificationRepository = notificationRepository;
        }
        public void Dispose()
        {
            return;
        }

        public async Task<Result<GenericResponse>> addNotification(HttpContext context, NotificationRequest not)
        {
            try
            {
                var u = _mapper.Map<UserModel>(context.Items["User"]);
                UserModel contatado = _userRepository.Select(not.UserId);
                UserModel user = _userRepository.Select(u.Id);
                _notificationRepository.deleteNotification(not.Id);
                Notification notification = new Notification();
                notification.Status = not.Status;
                notification.Read = false;
                notification.User = contatado;
                notification.Contatando = user;
                notification.Expires = DateTime.Now;
                contatado.Notification.Add(notification);
                _userRepository.Update(contatado);
                return new CustomResult<GenericResponse>(200)
                {

                    LogMessage = "",
                    Data = new GenericResponse
                    {
                        Response = "",
                        Statuscode = 200
                    }

                };
            }
            catch (Exception e)
            {
                return new CustomResult<GenericResponse>(200)
                {

                    LogMessage = "",
                    Data = new GenericResponse
                    {
                        Response = "erro interno",
                        Statuscode = 500
                    }

                };
            }
        }

        public void readNotification(HttpContext context)
        {
            var user = _mapper.Map<UserModel>(context.Items["User"]);
            _notificationRepository.readNotification(user.Id);
        }

        public void deleteNotification(HttpContext context, int NotificationId)
        {

            _notificationRepository.deleteNotification(NotificationId);
        }

        public async Task<Result<List<NotificationResponse>>> listNotifications(HttpContext context)
         {
            var user = _mapper.Map<UserModel>(context.Items["User"]);

            if (user == null)
            {
                return new CustomResult<List<NotificationResponse>>(401)
                {

                    LogMessage = "ok",
                    Data = new List<NotificationResponse>()

                };
            }
            var response = _notificationRepository.getNotifications(user.Id);

            List<NotificationResponse> notifications = new List<NotificationResponse>();
            response.ForEach(u =>
            {
                var contatando = _userRepository.Select(u.ContatandoId);
                var contact = _mapper.Map<NotificationResponse>(u);
                contact.Name = contatando.Name;
                contact.UserId = contatando.Id;
                notifications.Add(contact);
            });
            return new CustomResult<List<NotificationResponse>>(200)
            {

                LogMessage = "ok",
                Data = notifications

            };
        }

        public async Task<Result<GenericResponse>> sendInvitation(HttpContext context, int id)
        {
            var u = _mapper.Map<UserModel>(context.Items["User"]);
            UserModel contatado = _userRepository.Select(id);
            UserModel user = _userRepository.Select(u.Id);

            try
            { 
                Notification notification = new Notification();
                notification.Status = 0;
                notification.Read = false;
                notification.User = contatado;
                notification.Contatando = user;
                notification.Expires = DateTime.Now;
                contatado.Notification.Add(notification);
                _userRepository.Update(contatado);
            }
            catch (Exception e)
            {

                return new CustomResult<GenericResponse>(400)
                {

                    LogMessage = "ok",
                    Data = new GenericResponse { Response = "Solicitação já enviada", Statuscode = 400 }


                };
            }
            return new CustomResult<GenericResponse>(200)
            {

                LogMessage = "ok",
                Data = new GenericResponse { Response = "Solicitação enviada com sucesso", Statuscode = 200 }


            };

         }

        public async Task<Result<GenericResponse>> recuseInvitation(HttpContext context, int id, int notId)
        {
            var u = _mapper.Map<UserModel>(context.Items["User"]);
            UserModel contatado = _userRepository.Select(id);
            UserModel user = _userRepository.Select(u.Id);

            try
            {
                Notification notification = new Notification();
                notification.Status = 2;
                notification.Read = false;
                notification.User = contatado;
                notification.Contatando = user;
                notification.Expires = DateTime.Now;
                contatado.Notification.Add(notification);
                _userRepository.Update(contatado);
                _notificationRepository.deleteNotification(notId);
            }
            catch (Exception e)
            {

                return new CustomResult<GenericResponse>(400)
                {

                    LogMessage = "ok",
                    Data = new GenericResponse { Response = "Solicitação já enviada", Statuscode = 400 }


                };
            }
            return new CustomResult<GenericResponse>(200)
            {

                LogMessage = "ok",
                Data = new GenericResponse { Response = "Solicitação enviada com sucesso", Statuscode = 200 }


            };

        }

        public async Task<Result<GenericResponse>> verifyNotification(HttpContext httpContext)
        {
            var user = _mapper.Map<UserModel>(httpContext.Items["User"]);
          
                var ret = _notificationRepository.verifyNotification(user.Id);
                return new CustomResult<GenericResponse>(200)
                {

                    LogMessage = "ok",
                    Data = new GenericResponse { Response = ret.ToString(), Statuscode = 200 }


                };
        }
    }
}
