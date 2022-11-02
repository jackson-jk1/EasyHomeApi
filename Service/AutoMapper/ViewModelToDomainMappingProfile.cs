using AutoMapper;
using Domain.Models;
using Domain.Request.Auth;
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
        }
    }
}
