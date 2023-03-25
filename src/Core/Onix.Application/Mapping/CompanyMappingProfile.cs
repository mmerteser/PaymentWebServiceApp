using AutoMapper;
using Onix.Application.DTOs.CompanyDTOs;
using Onix.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onix.Application.Mapping
{
    internal class CompanyMappingProfile : Profile
    {
        public CompanyMappingProfile()
        {
            CreateMap<CompanyInformation, SimpleCompanyInformationDTO>();
        }
    }
}
