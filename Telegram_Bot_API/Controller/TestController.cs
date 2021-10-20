using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controller
{
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("test")]
        public string Get()
        {
            return "Tech42 .NET Currency API";
        }
    }
}
