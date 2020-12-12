using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice4.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        public string Phone { get; set; }
        public bool Confirmed { get; set; }

    }
}
