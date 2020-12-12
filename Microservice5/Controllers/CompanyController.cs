using Microservice5.Domain.Contracts;
using Microservice5.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        readonly IStockExchangeService service;
        public CompanyController(IStockExchangeService service)
        {
            this.service = service;
        }

        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201)]
        public IActionResult AddCompany(CompanyDto company)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            var result = service.AddCompany(company);
            if (!result)
                return BadRequest("Error saving Company");

            //return CreatedAtRoute("GetProductById", new { id = obj.ID });
            return StatusCode(201);
        }

        [HttpGet]
        [Route("{stockExchangeName}/companies")]
        public IActionResult GetCompaniesInStockExchange(string stockExchangeName)
        {
            return Ok(service.GetCompaniesInStockExchange(stockExchangeName));
        }
    }
}
