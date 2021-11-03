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
            StringBuilder str = new StringBuilder();
            foreach (var item in _currencyRepository.All().Select(Map))
            {
                str.AppendLine(item);
            }
            return str.ToString();
        }
        private string Map(Currency currency)
        {
            return currency.Code + "-" + currency.Description;
        }
    }
}
