using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice2.Entities
{
    public class Ipo
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string CompanyName { get; set; }
        [StringLength(30)]
        public string StockExchange { get; set; }
        public int PricePerShare { get; set; }
        public int TotalNumberOfShares {get;set;}
        public DateTime OpenDateTime{get;set;}
        public string Remarks { get; set; }
    }
}
