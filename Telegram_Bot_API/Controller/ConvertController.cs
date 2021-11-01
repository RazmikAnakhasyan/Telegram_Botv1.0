using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Model;
using System.Collections.Generic;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConvertController : ControllerBase
    {
        private readonly ICurrencies _currencies;
        public ConvertController(ICurrencies currencies)
        {
            _currencies = currencies;
        }

        [Route("/{currency}/all")]
        [HttpGet]
        public List<CurrenciesConvertDetails> All(string currency, double amount)
        {
            return _currencies.GetConvertInfoForAllCurrencies(currency, amount);
        }
    }
}
