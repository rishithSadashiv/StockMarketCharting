using Microservice3.Domain.Contracts;
using Microservice3.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        readonly ICompanyService companyService;
        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        [HttpGet]
        [Route("{id}/company")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(CompanyDto))]
        public IActionResult GetCompany(int id)
        {
            var Obj = companyService.GetCompany(id);
            if (Obj == null)
                return NotFound();

            return Ok(Obj);
        }

        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [ProducesResponseType(201)]
        public IActionResult UpdateCompany(CompanyDto obj)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (obj == null)
                return BadRequest("Product is required");

            var prod = companyService.GetCompany(obj.CompanyID);

            if (prod == null)
            {
                companyService.AddCompany(obj);
                return StatusCode(201);
            }
            var result = companyService.UpdateCompany(obj);
            if (result)
                return Ok();
            else
                return BadRequest("Update failed");


        }


        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201)]
        public IActionResult AddCompany(CompanyDto company)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            var result = companyService.AddCompany(company);
            if (!result)
                return BadRequest("Error saving products");

            //return CreatedAtRoute("GetProductById", new { id = obj.ID });
            return StatusCode(201);
        }

        [HttpGet]
        [Route("{sector}/sectorprice")]
        public IActionResult getSectorPrice(string sector)
        {
            int data = companyService.getSectorPrice(sector);
            return Ok(data);
        }

        [HttpGet]
        [Route("{sector}/companies")] //standard way of defining the request
        public IActionResult GetCompaniesInSector(string sector)
        {
            var data = companyService.GetCompaniesInSector(sector);
            return Ok(data);
        }


    }
}
