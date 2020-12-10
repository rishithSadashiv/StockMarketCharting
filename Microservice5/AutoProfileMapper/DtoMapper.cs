using Microservice5.Dtos;
using Microservice5.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;


namespace Microservice5.AutoProfileMapper
{
    public class DtoMapper: Profile
    {
        public DtoMapper()
        {
            CreateMap<Company, CompanyDto>().ReverseMap();
            CreateMap<StockExchange, StockExchangeDto>().ReverseMap();
        }
    }
}
