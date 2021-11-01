using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Model;
using System.Collections.Generic;
using Core.Services;
using Shared.Models;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Route("api/[controller]/convert")]
    public class ConvertController : ControllerBase
    {
        private readonly IBestAvailableRateService _bestAvailableRate;
        private readonly ICurrencies _currencies;
        public ConvertController(ICurrencies currencies, IBestAvailableRateService bestAvailableRate)
        {
            _currencies = currencies;
            _bestAvailableRate = bestAvailableRate;
        }

        [Route("/{currency}/all")]
        [HttpGet]
        public List<CurrenciesConvertDetails> All(string currency, double amount)
        {
            return _currencies.GetConvertInfoForAllCurrencies(currency, amount);
        }

        [HttpGet]
        public IActionResult Get(string fromCurrency, string toCurrency, decimal amount)
        {
            BestAvailableRate r = _bestAvailableRate.GetBestAvailableRate(fromCurrency, toCurrency, amount);
            return Content(@"value :" + r.Amount + ", best :" + r.BankName);
        }

    }
}
