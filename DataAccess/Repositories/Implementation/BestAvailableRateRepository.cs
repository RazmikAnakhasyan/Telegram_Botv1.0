using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    internal  class BestAvailableRateRepository:IBestAvailableRateRepository
    {
        private readonly DBModel _context;
        public BestAvailableRateRepository(DBModel context)
        {
            _context = context;
        }
        public List<Rate> AvailableRates()
        {

            List<Rate> availableRates=new List<Rate>() ;
        
            foreach (Bank bank in _context.Banks)
            {

                foreach (Currency currency in _context.Currencies)
                {
                    availableRates.Add(
                    _context.Rates.First(_ => _.Bank.Id == bank.Id && _.FromCurrency.Code ==currency.Code && _.LastUpdated ==
                    _context.Rates.OrderByDescending(_ => _.LastUpdated).FirstOrDefault().LastUpdated)

                    );
                }
            }

            return availableRates;


        }

        public string GetBankName(int bankID)
        {
            return _context.Banks.Where(_ => _.Id == bankID).FirstOrDefault().BankName;
        }
    }
}
