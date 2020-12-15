using AutoMapper;
using Microservice4.Dtos;
using Microservice4.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice4.AutoMapperProfiles
{
    public class DtoMapper:Profile
    {
        public DtoMapper()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
