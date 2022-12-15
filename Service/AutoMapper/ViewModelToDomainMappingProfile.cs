using AutoMapper;
using Domain.Models;
using Domain.Request.Auth;
using Domain.ViewModels.Response.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UserRequest, UserModel>().ConstructUsing(itemRequest =>  new UserModel
            {
                Name = itemRequest.Name,    
                Email = itemRequest.Email,
                CellPhone =  itemRequest.CellPhone, 
            });

            CreateMap<UserResponse, UserModel>().ConstructUsing(itemRequest => new UserModel
            {
                Id = itemRequest.Id,
                Name = itemRequest.Name,
                Email = itemRequest.Email,
                CellPhone = itemRequest.CellPhone,
                Image = itemRequest.Image,
                
            });
        }
    }
}
