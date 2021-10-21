using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Models.Rates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controller
{
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IBankService _bankService;
        public TestController(IBankService bankService)
        {
            _bankService = bankService;
        }
        [HttpGet("test")]
        public IEnumerable<Rates> Get()
        {
            return _bankService.AllRates();
        }
      
    }
}
