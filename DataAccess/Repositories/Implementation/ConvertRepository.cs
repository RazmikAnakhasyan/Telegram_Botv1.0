﻿using DataAccess.Models;
using DataAccess.Repositaries.Interfaces;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositaries.Services
{
    class ConvertRepository : IConvertRepository
    {
        private readonly DbModel _dBModel;
        private readonly IBestRatesRepository _bestRateRepository;
        private readonly string _baseCurrency = "AMD";

        public ConvertRepository(DbModel dBModel, IBestRatesRepository bestRatesRepository)
        {
            _dBModel = dBModel;
            _bestRateRepository = bestRatesRepository;
        }
        public List<CurrenciesConvertDetails> GetConvertDetails(string currency, double exchangedValue)
        {
            List<CurrenciesConvertDetails> convertDetails = new();
            var currencies = _dBModel.Currencies.Where(_ => _.Code != currency).Select(_ => _.Code);
            var bests = _bestRateRepository.GetBestRates();

            foreach (var toCurrency in currencies)
            {
                CurrenciesConvertDetails currenciesConvert = new();
                currenciesConvert.To = toCurrency;


                if (toCurrency == _baseCurrency)
                {
                    if (bests.Count(_ => _.FromCurrency == currency) == 0) continue;
                    currenciesConvert.Value = bests.Where(_ => _.FromCurrency == currency).First().BuyValue * (decimal)exchangedValue;
                }
                else if(currency == _baseCurrency)
                {
                    if (bests.Count(_ => _.ToCurrency == currency) == 0) continue;
                    if (bests.Count(_ => _.FromCurrency == toCurrency) == 0) continue;
                    currenciesConvert.Value = (1 / bests.Where(_ => _.FromCurrency == toCurrency).First().BuyValue) * (decimal)exchangedValue;
                }
                else
                {
                    if (bests.Count(_ => _.FromCurrency == toCurrency) == 0) continue;
                    var fromCurrencyBest = bests.Where(_ => _.FromCurrency == currency).First().BuyValue;
                    var toCurrencyBest = bests.Where(_ => _.FromCurrency == toCurrency).First().BuyValue;
                    currenciesConvert.Value = (fromCurrencyBest / toCurrencyBest) * (decimal)exchangedValue;

                }

                convertDetails.Add(currenciesConvert);
             
            }

            return convertDetails;
        }
    }
}
