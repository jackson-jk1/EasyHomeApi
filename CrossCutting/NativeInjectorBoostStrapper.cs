using Data.Context;
using Data.Repository;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using Service.Interfaces;
using Service.Services;

namespace CrossCutting

{
    public static class NativeInjectorBoostStrapper 
    {
        public static void RegisterServices(IServiceCollection service)
        {
            //////////////////////  instancias log //////////////////////   
            service.AddSingleton<IlogService, LogService>();

            //////////////////////  instancias de repository //////////////////////   
            service.AddScoped<IBaseRepository<UserModel>, BaseRepository<UserModel>>();
            service.AddScoped<IUserRepository, UserRepository>();

            //////////////////////  instancias de service //////////////////////   
            service.AddScoped<IUserService, UserService>();

            //////////////////////  instancias de contexto //////////////////////   
            service.AddScoped<MySqlContext>();

            


        }
    }
}
