using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Domain.Request.Auth;
using Domain.Utils.Result;
using Domain.ViewModels.Request;
using Domain.ViewModels.Response.Auth;
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
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private readonly IHostingEnvironment _appEnvironment;
        private readonly IMapper _mapper;
        private readonly IUserRepository _baseRepository;

        public UserService(IHostingEnvironment environment, IMapper mapper, IUserRepository baseRepository)
        {
            _appEnvironment = environment;
            _mapper = mapper;
            _baseRepository = baseRepository;
        }
        public void Dispose()
        {
            return;
        }

        public async Task<Result<LoginResponse>> Auth(LoginRequest user)
        {
            var userJwt = _baseRepository.Auth(user.Email);
            if (!userJwt.Equals(default) && userJwt.Password == EncryptHelper.Encrypt(user.Password))
                return new CustomResult<LoginResponse>(200){
                    LogMessage = "Autentificado",
                    Data = new LoginResponse
                    {
                        Token = GenerateToeken.TokenJwt(userJwt)
                    }
                };
            return new CustomResult<LoginResponse>(401)
            {

                LogMessage = "não autorizado",
                Data = new LoginResponse { Token = "" }
            };
        }

        public async Task<Result<GenericResponse>> Register(UserRequest userreq)
        {
            
            string nomeUnicoArquivo = ImageHelper.UploadedFile(userreq.Image, _appEnvironment.WebRootPath);
            var user = _mapper.Map<UserModel>(userreq);
            user.Image = nomeUnicoArquivo;
            user.Password = EncryptHelper.Encrypt(userreq.Password);
            _baseRepository.Insert(user);
            return new CustomResult<GenericResponse>(200)
            {

                LogMessage = "ok",
                Data = new GenericResponse { Response = "Registrado com sucesso", Statuscode = 200 }


            };
        }

        public async Task<Result<GenericResponse>> UpdatePassword(HttpContext context, PasswordRequest passreq)
        {
            var user = (UserModel)context.Items["User"];
            if (user.Password == EncryptHelper.Encrypt(passreq.PasswordNew))
            {
                user.Password = EncryptHelper.Encrypt(passreq.PasswordNew);
                _baseRepository.Update(user);
                return new CustomResult<GenericResponse>(200)
                {

                    LogMessage = "ok",
                    Data = new GenericResponse { Response = "Senha Atualizada com sucesso", Statuscode = 200 }

                };
            }
            return new CustomResult<GenericResponse>(400)
            {

                LogMessage = "ok",
                Data = new GenericResponse { Response = "Não foi possivel atualizar a senha", Statuscode = 400 }

            };

        }
        public async Task<Result<GenericResponse>> Update(HttpContext context, UserRequest userreq)
        {
            var user = (UserModel)context.Items["User"];
            string nomeUnicoArquivo = ImageHelper.UploadedFile(userreq.Image, _appEnvironment.WebRootPath);
            if (nomeUnicoArquivo != null)
            {
                ImageHelper.DestroyFile(user.Image, _appEnvironment.WebRootPath);
                user.Image = nomeUnicoArquivo;
            }
            user.Email = userreq.Email;
            user.CellPhone = userreq.CellPhone;
            user.Name = userreq.Name;
            _baseRepository.Update(user);
            return new CustomResult<GenericResponse>(200)
            {

                LogMessage = "ok",
                Data = new GenericResponse
                {
                    Response = "Atualizado com sucesso" ,
                    Statuscode = 200
                }

            };
        }

        public async Task<Result<GenericResponse>> Recover(string email)
        {
            var userJwt = _baseRepository.Auth(email);
            if (!userJwt.Equals(default))
            {
                string caracteres = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?_-";
                char[] chars = new char[8];
                Random rd = new Random();
                for (int i = 0; i < 8; i++)
                {
                    chars[i] = caracteres[rd.Next(0, caracteres.Length)];
                }
                var password = new string(chars);
                userJwt.Password = EncryptHelper.Encrypt(password);
                _baseRepository.Update(userJwt);
                SendGridHelper.Send(userJwt,password);
                return new CustomResult<GenericResponse>(200)
                {
                    LogMessage = "Enviamos enviado",
                    Data = new GenericResponse
                    {
                        Response = "Enviamos um email para sua conta",
                        Statuscode = 200
                    }
                };
            }
            return new CustomResult<GenericResponse>(401)
            {

                LogMessage = "Email não encontrado na base de dados",
                Data = new GenericResponse
                {
                    Response = "Email não encontrado na base de dados",
                    Statuscode = 401
                }

            };
        }

        public async Task<Result<UserModel>> GetById(int id)
         {
            return new CustomResult<UserModel>(200) {
               
                LogMessage = "ok",
                Data = _baseRepository.Select(id) 

            };
          
         }
    }
}
