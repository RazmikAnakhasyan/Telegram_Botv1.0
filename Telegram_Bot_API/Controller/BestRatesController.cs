using AutoMapper;
using Core.Model;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class BestRatesController : ControllerBase
    {
        private readonly IBestRateService _bestRates;

        public BestRatesController(IBestRateService bestRates)
        {
            _bestRates = bestRates;
        }

        [HttpGet]
        public List<CurrencyRate> GetBestRates()
        {
            return _bestRates.GetBestRates();
        }
    }
}
