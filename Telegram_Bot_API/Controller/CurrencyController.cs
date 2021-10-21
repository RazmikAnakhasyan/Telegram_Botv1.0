using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Models.Currency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controller
{
    [ApiController]
    public class CurrencyController:ControllerBase
    {
        private readonly ICurrencyService _currencyService;
        public CurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }
        [HttpGet("/api/currency/available")]
        public IEnumerable<Currency> Get()
        {
            return _currencyService.Available();
        }
    }
}
