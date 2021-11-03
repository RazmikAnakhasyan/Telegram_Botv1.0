using AutoMapper;
using Core.Services.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
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
        public IEnumerable<BestRateModel> GetBestRates()
        {
            return _bestRates.GetBestRates();
        }
    }
}
