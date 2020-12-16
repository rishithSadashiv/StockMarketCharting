using Microservice2.Domain.Contracts;
using Microservice2.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SectorApiClient;

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
        public async Task<IActionResult> AddCompany(Dtos.CompanyDto Company)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            var result = companyService.AddCompany(Company);
            if (!result)
                return BadRequest("Error saving products");

            //var client1 = new SectorApiClient.SectorApiClient("https://localhost:57532"); //tried it, not working, call it from UI itself.
            //SectorApiClient.CompanyDto comp1 = new SectorApiClient.CompanyDto()
            //{
            //    CompanyCode = Company.CompanyCode,
            //    CompanyName = Company.CompanyName,
            //    Sector = Company.Sector,
            //    Turnover = Company.Turnover
            //};
            //await client1.CompanyAsync(comp1) ;

            return StatusCode(201);
        }

        [HttpGet]
        [Route("{Id}/deactivateCompany")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(Dtos.CompanyDto))]
        public IActionResult DeactivateCompany(int Id)
        {
            try
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
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpDelete("{Id}")]
        public IActionResult DeleteCompany(int Id)
        {
            try
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
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Dtos.CompanyDto[]))]
        public IActionResult GetAllCompanies()
        {
            var Data = companyService.GetAllCompanies();
            return Ok(Data);
        }

        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [Route("{name}/companiesLike")]
        [ProducesResponseType(200, Type = typeof(Dtos.CompanyDto[]))]
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
            try
            {
                var Obj = companyService.GetCompany(Id);
                if (Obj == null)
                    return NotFound();

                return Ok(Obj);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public IActionResult UpdateCompany(Dtos.CompanyDto obj)
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
