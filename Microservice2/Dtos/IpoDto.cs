using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice2.Dtos
{
    public class IpoDto
    {
        public int IpoId { get; set; }
        [StringLength(30)]
        [Required(ErrorMessage = "Company Name is mandatory")]
        public string CompanyName { get; set; }
        [StringLength(30)]
        [Required(ErrorMessage = "Stock exchange is mandatory")]
        public string StockExchange { get; set; }
        [Required(ErrorMessage = "Company price is mandatory")]
        public int PricePerShare { get; set; }
        [Required(ErrorMessage = "Company shares is mandatory")]
        public int TotalNumberOfShares { get; set; }
        public DateTime OpenDateTime { get; set; }
        public string Remarks { get; set; }
    }
}
