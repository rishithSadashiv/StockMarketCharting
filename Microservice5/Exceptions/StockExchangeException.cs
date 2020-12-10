using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice5.Exceptions
{
    public class StockExchangeException:Exception
    {
        public string details { get; }
        public StockExchangeException(string details):base(details)
        {
            this.details = details;
        }
    }
}
