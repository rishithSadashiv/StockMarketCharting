using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice4.Dtos
{
    public class UserValidationResponseModel
    {
        public string Username { get; set; }
        public string UserType { get; set; }
        public string Jwt { get; set; }
    }
}
