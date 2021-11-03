
using DataAccess.Models;
using System.Collections.Generic;

namespace DataAccess.Repository
{
    internal class CurrencyRepository : ICurrencyRepository
    {
        private readonly DbModel _context;
        public CurrencyRepository(DbModel context)
        {
            _context = context;
        }
        public IEnumerable<Currency> All()
        {
            return _context.Currencies;
        }

    }
}
