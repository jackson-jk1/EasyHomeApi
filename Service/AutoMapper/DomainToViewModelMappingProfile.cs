using AutoMapper;
using Domain.Models;
using Domain.ViewModels.Response;
using Domain.ViewModels.Response.Auth;
using Domain.ViewModels.Response.Filtros;
using Domain.ViewModels.Response.Notificacoes;
using System.Text.Json;


namespace Service.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<UserModel, UserResponse>().ConstructUsing(model => new UserResponse
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                CellPhone = model.CellPhone,
                Image = model.Image,
                UserPreferences = model.UserPreferences,
                
            });
            CreateMap<UserModel, ContactResponse>().ConstructUsing(model => new ContactResponse
            {
                ContactId = model.Id,
                Name = model.Name,
                Email = model.Email,
                CellPhone = model.CellPhone,

            });

            CreateMap<Notification, NotificationResponse>().ConstructUsing(model => new NotificationResponse
            {
                Id = model.Id,
                UserId = model.UserId,
                Name = model.User.Name,
                Status = model.Status,
                Read = model.Read


            });
            CreateMap<PoloModel, PoloResponse>().ConstructUsing(model => new PoloResponse
            {
                Id = model.Id,
                Name = model.Name

            }) ;

            CreateMap<ImmobileModel, ImmobileResponse>().ConstructUsing(model => new ImmobileResponse
            {
                Id = model.Id,
                Desc = model.Desc,
                Price = model.Price,
                Rooms = model.Rooms,
                Address = model.Address,
                Bairro = model.Bairro,
                Title = model.Title,
                Map = model.Map,
                UserPreferences = model.UserPreferences,
               

            }) ; 
           
        }
    }
}
