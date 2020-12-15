using Microservice4.Dtos;
using Microservice4.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice4.Domain.Contracts
{
    public interface IUserRepository
    {
        public User getUser(int Id);

        public bool UpdateUser(User user);

        public bool AddUser(User dto);

        public UserValidationResponseModel Login(CredentialsModel cr);

    }
}
