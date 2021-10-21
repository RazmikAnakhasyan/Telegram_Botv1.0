using CodeFirst.Models;
using Shared.Models.Rates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class BankRepository : IBankRepository
    {
        private readonly DBModel _context;
        public BankRepository(DBModel context)
        {
            _context = context;
        }

        public IEnumerable<Rates> AllCurrency()
        {

            return (IEnumerable<Rates>)_context.Rates;
        }
    }
}
