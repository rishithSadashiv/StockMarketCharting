using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice5.Entities
{
    public class Company
    {
        
        public int Id { get; set; }
        [StringLength(10)]
        [Required]
        public string CompanyCode { get; set; }

        [Required]
        public string CompanyName { get; set; }

        public string StockExchangeName { get; set; }
        
    }
}
