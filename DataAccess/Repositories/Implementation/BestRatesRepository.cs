using DataAccess.Models;
using DataAccess.Repositaries.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositaries.Services
{
    class BestRatesRepository : IBestRatesRepository
    {
        private readonly DBModel _dBModel;
        public BestRatesRepository(DBModel dBModel)
        {
            _dBModel = dBModel;
        }
        public List<Rate> GetBestRates()
        {

            List<Rate> bestRates = new();
            List<string> rates = _dBModel.Currencies
                .Where(x=>x.Code != "AMD")
                .Select(_ => _.Code).ToList();
            foreach (var currency in rates)
            {
                try
                {
                    Rate rate = new();
                    rate.BuyValue = _dBModel.Rates
                           .Where(_ => _.ToCurrency.Code== currency && _.FromCurrency.Code == "AMD")
                           .Min(_ => _.BuyValue)
                           ;
                    rate.SellValue = _dBModel.Rates
                       .Where(_ => _.ToCurrency.Code == currency && _.FromCurrency.Code == "AMD")
                       .Max(_ => _.SellValue);
                  //  rate.ToCurrency = currency;
                    bestRates.Add(rate);
                }
                catch
                {
                    //TODO: Review
                }
            }
            return bestRates;
        }
    }
}
