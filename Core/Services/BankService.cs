using DataAccess.Repository;
using Shared.Models.Banks;
using Shared.Models.Rates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    class BankService:IBankService
    {
        private readonly IBankRepository _bankRepository;
        public BankService(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }

       public IEnumerable<Rates> AllRates()
        {
            return _bankRepository.All().Select(MapRates);
        }

        private Rates MapRates(Rates _rates)
        {
            return new Rates
            {
                ID = _rates.ID,
                BankId = _rates.BankId,
                BuyValue =_rates.BuyValue,
                FromCurrency = _rates.FromCurrency,
                LastUpdated = _rates.LastUpdated,
                SellValue = _rates.SellValue,
                ToCurrency = _rates.ToCurrency
            
            };
        }
    }
}
