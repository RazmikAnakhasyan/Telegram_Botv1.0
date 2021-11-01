using Core.Model;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Models.Currency;
using Shared.Models.Rates;
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
        private readonly IBankService _bankService;
        public CurrencyController(ICurrencyService currencyService, IBankService bankService)
        {
            _currencyService = currencyService;
            _bankService = bankService;
        }

        [HttpGet("/api/currency/available")]
        public IEnumerable<CurrencyModel> Get()
        {
            return _currencyService.Available();
        }

        [HttpGet("/api/currency/all")]
        public IEnumerable<RatesInfoModel> GetAll()
        {
            return _bankService.AllRates();
        }
    }
}
