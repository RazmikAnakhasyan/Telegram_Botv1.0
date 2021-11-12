using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implementation
{
    public class RatesRepository : IRatesRepository
    {
        private readonly DbModel _db;
        public RatesRepository(DbModel db)
        {
            _db = db;
        }
        public void BulkInsert(IEnumerable<Rate> rate)
        {
            var maxIteration =  _db.Rates.Count() == 0 ? 1 : _db.Rates.Max(_ => _.Iteration) + 1;
            var availables = _db.Currencies.Select(_ => _.Code).ToList();
            var ratesToAdd = rate.Where(_ => availables.Contains(_.FromCurrency))
                .GroupBy(_ => $"{_.BankId}{_.FromCurrency}")
                .Select(_ => _.First())
                .ToList();
            
            foreach (var item in ratesToAdd)
            {
                item.LastUpdated = DateTime.Now;
                item.Iteration = maxIteration;
            }

            _db.Rates.AddRange(ratesToAdd);
            _db.SaveChanges();
        }
    }
}
