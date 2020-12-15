using Microservice4.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice4.Domain.Contracts
{
    public interface IUserService
    {
        public UserDto getUser(int Id);

        public bool UpdateUser(UserDto user);

        public bool AddUser(UserDto dto);

        public UserValidationResponseModel Login(CredentialsModel cr);
    }
}
