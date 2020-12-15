using AutoMapper;
using Microservice4.Domain.Contracts;
using Microservice4.Dtos;
using Microservice4.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice4.Domain.Services
{
    public class UserService : IUserService
    {

        readonly IUserRepository repository;
        readonly IMapper mapper;
        public UserService(IUserRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public bool AddUser(UserDto dto)
        {
            var Obj = mapper.Map<User>(dto);
            return repository.AddUser(Obj);
        }

        public UserDto getUser(int Id)
        {
            var Obj = repository.getUser(Id);
            var Dto = mapper.Map<UserDto>(Obj);
            return Dto;
        }

        public UserValidationResponseModel Login(CredentialsModel cr)
        {
            var Obj = repository.Login(cr);
            return Obj;
        }

        public bool UpdateUser(UserDto user)
        {
            var Obj = mapper.Map<User>(user);
            return repository.UpdateUser(Obj);
        }
    }
}
