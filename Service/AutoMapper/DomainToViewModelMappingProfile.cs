using AutoMapper;
using Domain.Models;
using Domain.Request.Auth;
using Domain.ViewModels.Response.Auth;
using Domain.ViewModels.Response.Filtros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            CreateMap<PoloModel, PoloResponse>().ConstructUsing(model => new PoloResponse
            {
                Id = model.Id,
                Name = model.Name

            }) ;
        }
    }
}
