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
            if (userJwt == null)
            {
                return new CustomResult<LoginResponse>(401)
                {
                    LogMessage = "não autorizado",
                    Data = new LoginResponse { Token = "" }
                };
            }
            if (userJwt.Password == EncryptHelper.Encrypt(user.Password))
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
            var user = _mapper.Map<UserModel>(context.Items["User"]);
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
            var user = _mapper.Map<UserModel>(context.Items["User"]);
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
            if (userJwt == null)
            {
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

        public async Task<Result<UserResponse>> GetById(int id)
         {
            return new CustomResult<UserResponse>(200) {
               
                LogMessage = "ok",
                Data = _mapper.Map<UserResponse>(_baseRepository.Select(id)) 

            };
          
         }
        public async Task<Result<List<UserResponse>>> getUsersByImmobile(HttpContext context, int immId)
        {
            var user = _mapper.Map<UserModel>(context.Items["User"]);

            if (user == null)
            {
                return new CustomResult<List<UserResponse>>(401)
                {

                    LogMessage = "ok",
                    Data = new List<UserResponse>()

                };
            }
            var response = _baseRepository.getUsersByImmobile(user.Id, immId);
            List<UserResponse> users = new List<UserResponse>();
            response.ForEach(u =>
            {
                users.Add(_mapper.Map<UserResponse>(u));
            });
            return new CustomResult<List<UserResponse>>(200)
            {

                LogMessage = "ok",
                Data = users

            };

        }

        public async Task<Result<UserResponse>> GetByToken(HttpContext context)
        {
            var user = _mapper.Map<UserModel>(context.Items["User"]);

            if (user == null)
            {
              return  new CustomResult<UserResponse>(401)
                {

                    LogMessage = "ok",
                    Data = null

                };
            }
            return new CustomResult<UserResponse>(200)
                {

                    LogMessage = "ok",
                    Data = _mapper.Map<UserResponse>(_baseRepository.Select(user.Id))

            };

        }

        public async Task<Result<bool>> checkImmobile(HttpContext context, int immId)
        {
            var user = _mapper.Map<UserModel>(context.Items["User"]);

            return new CustomResult<bool>(200)
            {

                LogMessage = "",
                Data = _baseRepository.CheckImmobil(user.Id, immId),
             
            };
        }

        public async Task<Result<GenericResponse>> addFavorite(HttpContext context, int immId)
        {
            var user = _mapper.Map<UserModel>(context.Items["User"]);

            try
            {
                _baseRepository.AddFavorite(user.Id, immId);
                return new CustomResult<GenericResponse>(200)
                {

                    LogMessage = "",
                    Data = new GenericResponse
                    {
                        Response = "Adicionado com sucesso",
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
                        Response = "Não foi possivel adicional o imovel",
                        Statuscode = 500
                    }

                };
            }

        }

        public async Task<Result<GenericResponse>> removeFavorite(HttpContext context, int immId)
        {
            var user = _mapper.Map<UserModel>(context.Items["User"]);

            try
            {
                _baseRepository.removeFavorite(user.Id, immId);
                return new CustomResult<GenericResponse>(200)
                {

                    LogMessage = "",
                    Data = new GenericResponse
                    {
                        Response = "Removido com sucesso",
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
                        Response = "Não foi possivel remover o imovel",
                        Statuscode = 500
                    }

                };
            }

        }
    }
}
