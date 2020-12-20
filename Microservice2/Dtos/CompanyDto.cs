using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice2.Dtos
{
    public class CompanyDto
    {
        public int CompanyId { get; set; }
        [StringLength(30)]
        [Required(ErrorMessage = "Company name is mandatory")]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "Company turnover is mandatory")]
        public int Turnover { get; set; }
        [StringLength(30)]
        [Required(ErrorMessage = "Company code is mandatory")]
        public string CompanyCode { get; set; }
        [StringLength(30)]
        [Required(ErrorMessage = "CEO is mandatory")]
        public string Ceo { get; set; }
        public string BoardOfDirectors { get; set; }
        [Required(ErrorMessage = "Sector is mandatory")]
        public string Sector { get; set; }
        [Required(ErrorMessage = "Stock price is mandatory")]
        public int CurrentStockPrice { get; set; }

        [Required(ErrorMessage = "Activation is mandatory")]
        public bool Active { get; set; }
    }
}
