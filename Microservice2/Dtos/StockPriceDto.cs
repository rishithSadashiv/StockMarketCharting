using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice2.Dtos
{
    public class StockPriceDto
    {
        public int Id { get; set; }
        [StringLength(30)]
        [Required(ErrorMessage = "Company Name is mandatory")]
        public string CompanyName { get; set; }
        [StringLength(30)]
        [Required(ErrorMessage = "Company stock exchange is mandatory")]
        public string StockExchange { get; set; }
        [Required(ErrorMessage = "Stock price is mandatory")]
        public int CurrentPrice { get; set; }
        public DateTime DateOfPrice { get; set; }
    }
}
