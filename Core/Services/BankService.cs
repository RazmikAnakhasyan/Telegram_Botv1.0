using DataAccess.Models;
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
    class BankService : IBankService
    {
        private readonly IBankRepository _bankRepository;
        public BankService(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }

        public IEnumerable<RatesInfoModel> AllRates()
        {
            return _bankRepository.All().Select(MapRates);
        }

        private RatesInfoModel MapRates(Rate _rates)
        {
            return new RatesInfoModel
            {
                ID = _rates.Id,
                BankId = _rates.Bank.Id,
                BuyValue = _rates.BuyValue,
                FromCurrency = _rates.FromCurrency.Code,
                LastUpdated = _rates.LastUpdated,
                SellValue = _rates.SellValue,
                ToCurrency = _rates.ToCurrency.Code

            };
        }
    }
}
