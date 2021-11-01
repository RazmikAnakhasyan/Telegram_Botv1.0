
using DataAccess.Models;
using System.Collections.Generic;

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
