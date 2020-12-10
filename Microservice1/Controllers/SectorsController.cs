using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservice3.Domain.Contracts;
using Microservice3.Domain.Repositories;
using Microservice3.Domain.Services;
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

    }
}
