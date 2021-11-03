using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Model;
using System.Collections.Generic;
using Core.Services;
using Shared.Models;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace API.Controller
{
    [ApiController]
    [Route("api/convert")]
    public class ConvertController : ControllerBase
    {
        private readonly IBestAvailableRateService _bestAvailableRate;
        private readonly ICurrencies _currencies;
        public ConvertController(ICurrencies currencies, IBestAvailableRateService bestAvailableRate)
        {
            _currencies = currencies;
            _bestAvailableRate = bestAvailableRate;
        }

        [HttpGet("{currency}/all")]
        [SwaggerResponse(200, Type = typeof(IEnumerable<CurrenciesConvertDetails>))]
        public IActionResult All(string currency, double amount)
        {
            if (amount == 0) return BadRequest("amount not specified");
            if (string.IsNullOrEmpty(currency)) return BadRequest("currency not specified");
            return Ok(_currencies.GetConvertInfoForAllCurrencies(currency, amount));
        }

        [HttpGet]
        public IActionResult Get(string fromCurrency, string toCurrency, decimal amount)
        {
            BestAvailableRate r = _bestAvailableRate.GetBestAvailableRate(fromCurrency, toCurrency, amount);
            return Ok(r);
        }

    }
}
