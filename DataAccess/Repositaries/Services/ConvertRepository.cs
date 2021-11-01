using DataAccess.Entities;
using DataAccess.Repositaries.Interfaces;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositaries.Services
{
    class ConvertRepository : IConvertRepository
    {
        private readonly DBModel _dBModel;

        public ConvertRepository(DBModel dBModel)
        {
            _dBModel = dBModel;
        }
        public List<CurrenciesConvertDetails> GetConvertDetails(string currency, double exchangedValue)
        {
            List<CurrenciesConvertDetails> convertDetails = new();
            List<Rate> context = _dBModel.Rates
                .Where(_ => _.FromCurrency == currency).ToList();
            foreach(var rates in context)
            {
                CurrenciesConvertDetails currenciesConvert = new();
                currenciesConvert.To = rates.ToCurrency.ToString();
                currenciesConvert.Value = Math.Round((double)rates.BuyValue * exchangedValue,2);
                convertDetails.Add(currenciesConvert);
            }
            return convertDetails;
        }
    }
}
