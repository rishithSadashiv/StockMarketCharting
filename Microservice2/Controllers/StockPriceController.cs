using Microservice2.Domain.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockPriceController : ControllerBase
    {

        readonly IStockPriceService stockPriceService;
        public StockPriceController(IStockPriceService stockPriceService)
        {
            this.stockPriceService = stockPriceService;
        }
    }
}
