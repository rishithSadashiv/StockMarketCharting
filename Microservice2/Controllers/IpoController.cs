﻿using Microservice2.Domain.Contracts;
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
    public class IpoController : ControllerBase
    {
        readonly IIpoService ipoService;
        public IpoController(IIpoService ipoService)
        {
            this.ipoService = ipoService;
        }

        [HttpPost]
        public IActionResult AddIpo(IpoDto Ipo)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            var result = ipoService.AddIpo(Ipo);
            if (!result)
                return BadRequest("Error saving products");

            //return CreatedAtRoute("GetProductById", new { id = obj.ID });
            return StatusCode(201);
        }


        [HttpDelete("{ipo}")]
        public IActionResult DeleteIpo(int ipo)
        {
            var result = ipoService.DeleteIpo(ipo);
            if (!result)
            {
                return BadRequest("Some error occured");
            }
            else
            {
                return Ok("IPO deleted");
            }
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IpoDto[]))]
        public IActionResult GetAllIpos()
        {
            var Data = ipoService.GetAllIpos();
            return Ok(Data);
        }


        [HttpGet]
        [Route("{name}/company")]
        [ProducesResponseType(200, Type = typeof(IpoDto[]))]
        public IActionResult GetIposOfCompany(string name)
        {
            if(name == null)
            {
                return BadRequest("company name required");
            }

            var Data = ipoService.GetIposOfCompany(name);
            return Ok(Data);
        }


        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public IActionResult UpdateCompany(IpoDto obj)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (obj == null)
                return BadRequest("Product is required");

            var result = ipoService.UpdateIpo(obj);
            if (result)
                return Ok();
            else
                return BadRequest("Update failed");
        }

    }
}
