using AutoMapper;
using Microservice3.Dtos;
using Microservice3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice3.AutoProfileMappers
{
    public class DtoMapper:Profile
    {
        public DtoMapper()
        {
            CreateMap<Company, CompanyDto>();
            CreateMap<Sector, SectorDto>();
        }
    }
}
