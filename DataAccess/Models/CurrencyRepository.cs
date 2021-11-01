using CodeFirst.Models;
using Shared.Models.Currency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repository;

namespace DataAccess.Repository
{
    internal class CurrencyRepository : ICurrencyRepository
    {
        private readonly DBModel _context;
        public CurrencyRepository(DBModel context)
        {
            _context = context;
        }
        public IEnumerable<Currency> All()
        {
            return _context.Currencies;
        }
    }
}
