using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice3.Entities
{
    public class Sector
    {
        public int SectorID { get; set; }
        [StringLength(30)]
        public string SectorName { get; set; }
        [StringLength(30)]
        public string Brief { get; set; }
    }
}
