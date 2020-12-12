using Microservice2.Domain.Contracts;
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
    }
}
