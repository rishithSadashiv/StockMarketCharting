using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice2.Entities
{
    public class StockPrice
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string CompanyName { get; set; }
        [StringLength(30)]
        public string StockExchange{ get; set; }
        public int CurrentPrice { get; set; }
        public DateTime DateOfPrice { get; set; }

    }
}
