using DataAccess.Models;
using DataAccess.Repositaries.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.Infrastructure;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositaries.Services
{
    class BestRatesRepository : IBestRatesRepository
    {
        private readonly DbModel _dBModel;
        private readonly string _baseCurrency;
        public BestRatesRepository(DbModel dBModel, ISettingsProvider settingsProvider)
        {
            _dBModel = dBModel;
            _baseCurrency = settingsProvider.BaseCurrency;
        }
        public IEnumerable<BestRateModel> GetBestRates()
        {

            List<BestRateModel> bestRates = new();
            var currencies = _dBModel.Currencies
                .Where(x => x.Code != _baseCurrency)
                .Select(_ => _.Code).ToList();

            var lastIteration = _dBModel.Rates.Max(_ => _.Iteration);
            var lastRates = _dBModel.Rates.Where(_ => _.Iteration == lastIteration);
               

            foreach (var currency in currencies)
            {
                var bestRateModel = new BestRateModel();

                var currencyRate = lastRates
                           .Where(_ => _.FromCurrency == currency && _.ToCurrency == _baseCurrency)
                           .Include(_ => _.Bank);

                var currencyRateBuy = currencyRate
                           .OrderByDescending(_ => _.BuyValue)
                           .FirstOrDefault();

                var currencyRateSell = currencyRate
                    .OrderBy(_ => _.SellValue)
                    .FirstOrDefault();
                if(currencyRateBuy != null)
                {
                    bestRateModel.BestBankForBuying = currencyRateBuy.Bank.BankName;
                    bestRateModel.BuyValue = currencyRateBuy.BuyValue;
                   
                }

                if(currencyRateSell != null)
                {
                    bestRateModel.BestBankForSelling = currencyRateSell.Bank.BankName;
                    bestRateModel.SellValue = currencyRateSell.SellValue;
                }

                if(currencyRateBuy != null || currencyRateSell != null)
                {
                    bestRateModel.FromCurrency = currency;
                    bestRateModel.ToCurrency = _baseCurrency;
                    bestRates.Add(bestRateModel);
                }
               
            }
            return bestRates;
        }

    }
}
