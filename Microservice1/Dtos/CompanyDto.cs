using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice3.Dtos
{
    public class CompanyDto
    {
        public int CompanyID { get; set; }
        [StringLength(30)]
        [Required(ErrorMessage = "Company Name is mandatory")]
        public string CompanyName { get; set; }
        [StringLength(10)]
        [Required]
        public string CompanyCode { get; set; }
        [StringLength(20)]
        [Required]
        public string Sector { get; set; }
        [Required]
        public int Turnover { get; set; }
    }
}
