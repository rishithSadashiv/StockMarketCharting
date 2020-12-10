using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservice3.Domain.Contracts;
using Microservice3.Domain.Repositories;
using Microservice3.Domain.Services;
using Microservice3.Dtos;
using Microservice3.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Microservice3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectorsController : ControllerBase
    {
        readonly ISectorService sectorService;
        readonly ICompanyService companyService;
        public SectorsController(ISectorService sectorService, ICompanyService companyService)
        {
            this.sectorService = sectorService;
            this.companyService = companyService;
        }
        [HttpGet]
        public IActionResult getSectors()
        {
            var data = sectorService.getSectors();
            return Ok(data);
        }
        [HttpGet]
        [Route("getCompaniesInSector/{sector}")]
        public IActionResult GetCompaniesInSector(string sector)
        {
            var data = companyService.GetCompaniesInSector(sector);
            return Ok(data);
        }
        [HttpGet]
        [Route("getSectorPrice/{sector}")]
        public IActionResult getSectorPrice(string sector)
        {
            int data = companyService.getSectorPrice(sector);
            return Ok(data);
        }

        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201)]
        [Route("addsector")]
        public IActionResult AddSector(SectorDto sector)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            var result = sectorService.AddSector(sector);
            if (!result)
                return BadRequest("Error saving products");

            //return CreatedAtRoute("GetProductById", new { id = obj.ID });
            return StatusCode(201);
        }


        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201)]
        [Route("addcompany")]
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

        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [Route("updatecompany")]
        public IActionResult UpdateCompany(CompanyDto obj)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (obj == null)
                return BadRequest("Product is required");

            var prod = companyService.GetCompany(obj.CompanyID);

            if (prod == null)
                return NotFound();

            var result = companyService.UpdateCompany(obj);
            if (result)
                return Ok();
            else
                return BadRequest("Update failed");
        }


        [HttpGet("{id}", Name = "GetCompanyById")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(CompanyDto))]
        public IActionResult GetProduct(int id)
        {
            var Obj = companyService.GetCompany(id);
            if (Obj == null)
                return NotFound();

            return Ok(Obj);
        }




    }
}
