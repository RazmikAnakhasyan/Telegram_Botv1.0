using DataAccess.Models;
using DataAccess.Repository;
using Shared.Models.Currency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    internal class CurrrencyService : ICurrencyService
    {
        private readonly ICurrencyRepository _currencyRepository;
        public CurrrencyService(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }
        public string Available()
        {
            return                   
        }
        private CurrencyModel MapCurrencies(Currency currency)
        {
            return new  CurrencyModel
            {
                Code = currency.Code
            };
        }
    }
}
