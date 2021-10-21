using CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
