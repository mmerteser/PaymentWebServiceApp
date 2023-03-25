using AutoMapper;
using Onix.Application.DTOs;
using Onix.Application.ViewModels.Authentication;
using Onix.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onix.Application.Mapping
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, LoginVM>().ReverseMap();
            CreateMap<ApplicationMenu, UserMenuDTO>().ReverseMap();
        }
    }
}
