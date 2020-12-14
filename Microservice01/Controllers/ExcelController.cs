using Microservice01.Domain.Contracts;
using Microservice01.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        [HttpPost]
        public IActionResult ExcelToDB([FromBody] StockPriceDto Dto)
        {
            return Ok();
        }
    }
}
