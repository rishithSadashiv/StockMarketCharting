using AutoMapper;
using Microservice2.Dtos;
using Microservice2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice2.AutoMapperProfiles
{
    public class DtoMapper:Profile
    {
        public DtoMapper()
        {
            CreateMap<Company, CompanyDto>().ReverseMap();
            CreateMap<Ipo, IpoDto>().ReverseMap();
            CreateMap<StockPrice, StockPriceDto>().ReverseMap();
        }
    }
}
