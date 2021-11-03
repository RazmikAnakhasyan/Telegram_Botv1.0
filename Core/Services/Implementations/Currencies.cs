using Core.Services.Interfaces;
using DataAccess.Repositaries.Interfaces;
using Shared.Model;
using System;
using System.Collections.Generic;

namespace Core.Services.Services
{
    public class Currencies : ICurrencies
    {
        private readonly IConvertRepository _convertRepository;
        public Currencies(IConvertRepository convertRepository)
        {
            _convertRepository = convertRepository;
        }

        public CurrenciesConvertDetails Convert(string from, string to, decimal amount)
        {
            return _convertRepository.Convert(from, to, amount);
        }

        public List<CurrenciesConvertDetails> GetConvertInfoForAllCurrencies(string currency, double exchangedValue)
        {
            return _convertRepository.GetConvertDetails(currency, exchangedValue);
        }
    }
}
