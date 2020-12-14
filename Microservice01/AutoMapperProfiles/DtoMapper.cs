using AutoMapper;
using Microservice01.Dtos;
using Microservice01.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice01.AutoMapperProfiles
{
    public class DtoMapper: Profile
    {
        public DtoMapper()
        {
            CreateMap<StockPrice, StockPriceDto>().ReverseMap();
        }
    }
}
