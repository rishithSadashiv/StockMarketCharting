using Microservice2.Domain.Contracts;
using Microservice2.Dtos;
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
    public class CompanyController : ControllerBase
    {
        readonly ICompanyService companyService;
        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(201)]
        [HttpPost]
        public IActionResult AddCompany(CompanyDto Company)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            var result = companyService.AddCompany(Company);
            if (!result)
                return BadRequest("Error saving products");

            //return CreatedAtRoute("GetProductById", new { id = obj.ID });
            return StatusCode(201);
        }

        [HttpGet]
        [Route("{Id}/deactivateCompany")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(CompanyDto))]
        public IActionResult DeactivateCompany(int Id)
        {
            if (Id == 0)
            {
                return BadRequest("company id is 0");
            }
            var result = companyService.DeactivateCompany(Id);
            if (!result)
            {
                return BadRequest("Some error occured");
            }
            else
            {
                return Ok("Company activated/deactivated");
            }
        }

        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpDelete("{Id}")]
        public IActionResult DeleteCompany(int Id)
        {
            if (Id == 0)
            {
                return BadRequest("company id is 0");
            }

            var result = companyService.DeleteCompany(Id);
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
        [ProducesResponseType(200, Type = typeof(CompanyDto[]))]
        public IActionResult GetAllCompanies()
        {
            var Data = companyService.GetAllCompanies();
            return Ok(Data);
        }

        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [Route("{name}/companiesLike")]
        [ProducesResponseType(200, Type = typeof(CompanyDto[]))]
        public IActionResult GetAllCompaniesLike(string name)
        {
            var Data = companyService.GetAllCompaniesLike(name);
            return Ok(Data);
        }

        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpGet("{Id}")]
        public IActionResult GetCompany(int Id)
        {
            var Obj = companyService.GetCompany(Id);
            if (Obj == null)
                return NotFound();

            return Ok(Obj);
        }

        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public IActionResult UpdateCompany(CompanyDto obj)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (obj == null)
                return BadRequest("Product is required");

            //var prod = companyService.GetCompany(obj.CompanyId);

            //if (prod == null)
              //  return NotFound();

            var result = companyService.UpdateCompnany(obj);
            if (result)
                return Ok();
            else
                return BadRequest("Update failed");
        }


    }
}
