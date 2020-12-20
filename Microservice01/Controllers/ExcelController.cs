using Microservice01.Domain.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyNamespace;

namespace Microservice01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelController : ControllerBase
    {
        readonly IExcelService service;
        public ExcelController(IExcelService excelService)
        {
            service = excelService;
        }

        //api/excel
        [HttpPost]
        public async Task<IActionResult> ExcelToDB([FromBody] StockPriceDto[] Dto)
        {
            var client = new CompanyApiClient("http://localhost:56959");
            foreach(var stockprice in Dto)
            {
                await client.StockPriceAsync(stockprice);
            }
            return Ok();
        }
    }
}
