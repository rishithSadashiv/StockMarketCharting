using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice3.Dtos
{
    public class SectorDto
    {
        public int SectorID { get; set; }
        [StringLength(30)]
        [Required(ErrorMessage = "Sector Name is mandatory")]
        public string SectorName { get; set; }
        [StringLength(30)]
        [Required]
        public string Brief { get; set; }
    }
}
