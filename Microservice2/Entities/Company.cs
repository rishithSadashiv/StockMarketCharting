using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice2.Entities
{
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompanyId { get; set; }
        [StringLength(30)]
        public string CompanyName { get; set; }
        public int Turnover { get; set; }
        [StringLength(30)]
        public string CompanyCode { get; set; }
        [StringLength(30)]
        public string Ceo { get; set; }
        [StringLength(50)]
        public string BoardOfDirectors { get; set; }
        public string Sector { get; set; }
        public int CurrentStockPrice { get; set; }
        public bool Active{ get; set; }
}
}
