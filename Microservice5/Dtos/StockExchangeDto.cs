using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice5.Dtos
{
    public class StockExchangeDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is mandatory")]
        public string StockExchangeName { get; set; }
        [StringLength(20)]
        public string Brief { get; set; }
        [StringLength(30)]
        public string ContactAddress { get; set; }
        [StringLength(15)]
        public string Remarks { get; set; }
    }
}
