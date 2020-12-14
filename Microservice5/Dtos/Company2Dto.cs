using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice3.Dtos
{
    public class Company2Dto
    {
        public int CompanyId { get; set; }
        
        public string CompanyName { get; set; }
  
        public int Turnover { get; set; }
      
        public string CompanyCode { get; set; }

        public string Ceo { get; set; }
        public string BoardOfDirectors { get; set; }
        
        public string Sector { get; set; }
      
        public int CurrentStockPrice { get; set; }
     
        public bool Active { get; set; }
    }
}
