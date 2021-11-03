using Core.Model;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Models.Currency;
using Shared.Models.Rates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TelegramBot;
using Microsoft.Extensions.Configuration;

namespace API.Controller
{
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;
        private readonly IBankService _bankService;
        public IConfiguration Configuration { get; }
        public CurrencyController(IBankService bankService, ICurrencyService currencyService)
        {
            _currencyService = currencyService;
            _bankService = bankService;
        }

        [HttpGet("/api/currency/available")]
        public string Get()
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
