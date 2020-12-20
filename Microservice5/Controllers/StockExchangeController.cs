using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservice5.Dtos;
using Microservice5.Domain.Contracts;

namespace Microservice5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockExchangeController : ControllerBase
    {
        readonly IStockExchangeService service;
        public StockExchangeController(IStockExchangeService service)
        {
            this.service = service;
        }


        [HttpGet]
        public IActionResult GetStockExchanges()
        {
            return Ok(service.GetStockExchanges());
        }

        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201)]
        public IActionResult AddStockExchange(StockExchangeDto stockExchange)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            var result = service.AddStockExchange(stockExchange);
            if (!result)
                return BadRequest("Error saving Stock Exchange");

            //return CreatedAtRoute("GetProductById", new { id = obj.ID });
            return StatusCode(201);
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Route("{company}/stockexchanges")]
        public IActionResult GetStockExchangesToWhichACompanyBelongsTo(string company)
        {
            if(company == "" || company == null)
            {
                return BadRequest("Company name is empty");
            }
            var Obj = service.GetAllStockExchangesToWhichACompanyBelongs(company);
            return Ok(Obj);
        }
        

    }
}
