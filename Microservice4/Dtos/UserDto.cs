using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice4.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Email is mandatory")]
        [StringLength(20)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is mandatory")]
        [StringLength(13)]
        public string Password { get; set; }
        [Required(ErrorMessage = "UserType is mandatory")]
        [StringLength(5)]
        public string UserType { get; set; }
        [StringLength(13)]
        public string Phone { get; set; }
        public bool Confirmed { get; set; }
    }
}
