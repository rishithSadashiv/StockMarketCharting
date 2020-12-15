using Microservice4.Domain.Contracts;
using Microservice4.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Microservice4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IUserService service;
        public AuthController(IUserService service)
        {
            this.service = service;
        }

        [HttpPost("register")]
        public IActionResult AddUser([FromBody] UserDto user)
        {
            try
            {
                if (ModelState.IsValid == false)
                    return BadRequest(ModelState);

                var result = service.AddUser(user);
                if (!result)
                    return BadRequest("Error saving user");

                //SendMail(user);

                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        private void SendMail(UserDto user)
        {
            var mail = new MailMessage();
            mail.Subject = "Test mail";
            mail.From = new MailAddress("rishusit7@gmail.com");
            mail.To.Add("rishith.1si16ec078@gmail.com");
            mail.Body = "<h1>Welcome to xyz</h1>";
            mail.IsBodyHtml = true;


            var smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 567;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential() { UserName = "rishusit7@gmail.com", Password = "12345" };

            smtp.Send(mail);

            return;
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public IActionResult GetUser(int Id)
        {
            var Obj = service.getUser(Id);
            if (Obj == null)
                return NotFound();

            return Ok(Obj);
        }

        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [ProducesResponseType(201)]
        public IActionResult UpdateUser([FromBody] UserDto user)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = service.UpdateUser(user);
                if (result)
                    return Ok();
                else
                    return BadRequest("Update failed");


            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("login")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public IActionResult Login([FromBody] CredentialsModel cr)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var result = service.Login(cr);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}
