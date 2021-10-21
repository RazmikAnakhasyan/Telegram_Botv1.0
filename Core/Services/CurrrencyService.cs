using CodeFirst.Models;
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
        public IEnumerable<ModelCurrency> Available()
        {
            return _currencyRepository.All().
                 Select(MapCurrencies);                    
        }
        private ModelCurrency MapCurrencies(Currency currency)
        {
            return new  ModelCurrency
            {
                Code = currency.Code
            };
        }
    }
}
