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
        public SectorsController(ISectorService sectorService)
        {
            this.sectorService = sectorService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(SectorDto))]
        public IActionResult GetSectors()
        {
            var data = sectorService.getSectors();
            return Ok(data);
        }
 
        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201)]
        public IActionResult AddSector(SectorDto sector)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            var result = sectorService.AddSector(sector);
            if (!result)
                return BadRequest("Error saving Sector");

            //return CreatedAtRoute("GetProductById", new { id = obj.ID });
            return StatusCode(201);
        }


    }
}
