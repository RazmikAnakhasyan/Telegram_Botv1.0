using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Model;
using System.Collections.Generic;
using Core.Services;
using Shared.Models;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using System.Linq;

namespace API.Controller
{
    [ApiController]
    [Route("api/convert")]
    public class ConvertController : ControllerBase
    {
        private readonly IBestRateService _bestAvailableRate;
        private readonly ICurrencies _currencies;
        private readonly string _baseCurrency = "AMD";
        public ConvertController(ICurrencies currencies, IBestRateService bestAvailableRate)
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
        public IActionResult Get(string from, string to, decimal amount)
        {
            if (amount == 0) return BadRequest("Amount must be specified");
            from = string.IsNullOrEmpty(from) ? "USD" : from;
            to = string.IsNullOrEmpty(to) ? _baseCurrency : to;

            var bestRates = _currencies.Convert(from, to, amount);
            return Ok(bestRates);
        }

    }
}
