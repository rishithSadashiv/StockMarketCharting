using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Microservice5.Dtos
{
    public class CompanyDto
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Company code is mandatory")]
        public string CompanyCode { get; set; }

        [Required(ErrorMessage = "Company name is mandatory")]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "Stock Exchange name is mandatory")]
        public string StockExchangeName { get; set; }
        // to be extracted from StockExchange table using StockExchangeName
        //public int stockExchangeId { get; set; }
    }
}
