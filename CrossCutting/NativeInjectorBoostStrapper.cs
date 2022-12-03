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
            service.AddScoped<IBaseRepository<PoloModel>, BaseRepository<PoloModel>>();
            service.AddScoped<IBaseRepository<ImmobileModel>, BaseRepository<ImmobileModel>>();
            service.AddScoped<IUserRepository, UserRepository>();

            //////////////////////  instancias de service //////////////////////   
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IImmobileService, ImmobileService>();
            service.AddScoped<IFiltrosService, FiltrosService>();

            //////////////////////  instancias de contexto //////////////////////   
            service.AddScoped<MySqlContext>();

            


        }
    }
}
