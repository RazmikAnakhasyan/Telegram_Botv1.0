using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implementation
{
    class DataScrapper : IDataScrapperRepository
    {
        private readonly DbModel _db;
        public DataScrapper(DbModel db)
        {
            _db = db;
        }
        public void BulknInsert(List<Rate> rate)
        {
            foreach (var item in rate)
            {
                _db.Add<Rate>(new Rate
                {
                    FromCurrency = item.FromCurrency,
                    ToCurrency = item.ToCurrency,
                    BuyValue = item.BuyValue,
                    SellValue = item.SellValue,
                    Iteration = item.Iteration,
                    BankId = item.BankId,
                    LastUpdated = DateTime.Now

                }) ;
                _db.SaveChanges();
            }
        }
    }
}
