using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice2.Entities
{
    public class StockPrice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StockPriceId { get; set; }
        [StringLength(30)]
        public string CompanyName { get; set; }
        [StringLength(10)]
        public string CompanyCode { get; set; }
        [StringLength(30)]
        public string StockExchange { get; set; }
        public int CurrentPrice { get; set; }
        public DateTime DateOfPrice { get; set; }

    }
}
