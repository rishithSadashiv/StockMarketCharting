using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice2.Entities
{
    public class Ipo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IpoId { get; set; }
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
