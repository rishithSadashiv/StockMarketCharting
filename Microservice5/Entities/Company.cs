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
        [Key]
        public int Id { get; set; }
        [StringLength(10)]
        [Column(TypeName = "varchar")]
        [Required]
        public string CompanyCode { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [ForeignKey("SName")]
        public string StockExchangeName { get; set; }
        public StockExchange stockExchange { get; set; }
    }
}
