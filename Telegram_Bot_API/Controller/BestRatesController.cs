using AutoMapper;
using Core.Model;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controller
{
    [ApiController]
    [Route("api/[controller]/best")]
    public class BestRatesController : ControllerBase
    {
        private readonly IBestRates _bestRates;

        public BestRatesController(IBestRates bestRates)
        {
            _bestRates = bestRates;
        }
        [HttpPost("BestRates")]
        public List<CurrencyRate> GetBestRates()
        {
            return _bestRates.GetBestRates();
        }
    }
}
