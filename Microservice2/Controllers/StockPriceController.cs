using Microservice2.Domain.Contracts;
using Microservice2.Dtos;
using Microservice2.Entities;
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


        [HttpPost]
        public IActionResult AddCompany(StockPriceDto Obj)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            var result = stockPriceService.AddStockPrice(Obj);
            if (!result)
                return BadRequest("Error saving products");

            //return CreatedAtRoute("GetProductById", new { id = obj.ID });
            return StatusCode(201);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteStockPrice(int id)
        {

            var result = stockPriceService.DeleteStockPrice(id);
            if (!result)
            {
                return BadRequest("Some error occured");
            }
            else
            {
                return Ok("Company deleted");
            }
        }


        [HttpGet]
        [Route("{name}/company")]
        [ProducesResponseType(200, Type = typeof(IpoDto[]))]
        public IActionResult GetIposOfCompany(string name)
        {
            if (name == null)
            {
                return BadRequest("company name required");
            }

            var Data = stockPriceService.GetAllStockPricesOfCompany(name);
            return Ok(Data);
        }


        [HttpGet]
        [Route("{name}/{fromDate}/{toDate}/stockPrices")]
        [ProducesResponseType(200, Type = typeof(IpoDto[]))]
        public IActionResult GetAllStockPricesOfCompanyBetweenDates( string name, DateTime fromDate, DateTime toDate)
        {
            if (name == null || fromDate == null || toDate == null)
            {
                return BadRequest("inputs required");
            }

            var Data = stockPriceService.GetAllStockPricesOfCompanyBetweenDates(name, fromDate, toDate);
            return Ok(Data);
        }



    }
}
