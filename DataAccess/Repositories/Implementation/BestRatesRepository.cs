using DataAccess.Models;
using DataAccess.Repositaries.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositaries.Services
{
    class BestRatesRepository : IBestRatesRepository
    {
        private readonly DbModel _dBModel;
        private readonly string _baseCurrency = "AMD";
        public BestRatesRepository(DbModel dBModel)
        {
            _dBModel = dBModel;
        }
        public List<Rate> GetBestRates()
        {

            List<Rate> bestRates = new();
            var currencies = _dBModel.Currencies
                .Where(x => x.Code != _baseCurrency)
                .Select(_ => _.Code).ToList();
            var banks = _dBModel.Banks.ToList();

            var query = _dBModel.Rates.OrderBy(_ => _.LastUpdated);


            foreach (var currency in currencies)
            {
                try
                {
                    Rate rate = new();
                    rate.BuyValue = _dBModel.Rates
                           .Where(_ => _.ToCurrency == currency && _.FromCurrency == _baseCurrency)
                           .Min(_ => _.BuyValue)
                           ;
                    rate.SellValue = _dBModel.Rates
                       .Where(_ => _.ToCurrency == currency && _.FromCurrency == _baseCurrency)
                       .Max(_ => _.SellValue);
                     rate.ToCurrency = currency;
                    bestRates.Add(rate);
                }
                catch (Exception ex)
                {
                    //TODO: Review
                }
            }
            return bestRates;
        }

       
    }
    public class BestRateModel
    {
        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
        public string BankName { get; set; }
        public double BuyValue { get; set; }
        public double SellValue { get; set; }
    }
}
