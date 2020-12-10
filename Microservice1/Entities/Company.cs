using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice3.Entities
{
    public class Company
    {
        public int CompanyID { get; set; }
        [StringLength(30)]
        public int CompanyName { get; set; }
        [StringLength(10)]
        public string CompanyCode { get; set; }
        [StringLength(20)]
        public string Sector { get; set; }

        public int Turnover { get; set; }
    }
}
