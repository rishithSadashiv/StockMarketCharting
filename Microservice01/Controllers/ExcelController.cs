using Microservice01.Domain.Contracts;
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

        [HttpGet("{Path}")]
        public IActionResult ExcelToDB(string Path)
        {
            if(Path == null)
            {
                return BadRequest("Path cannot be empty");
            }
            var Result = service.ExcelToDB(Path);
            if (Result)
            {
                return Ok("Excel data added to DB");
            }
            else
            {
                return BadRequest("There was some error,could not add data to DB");

            }
        }
    }
}
