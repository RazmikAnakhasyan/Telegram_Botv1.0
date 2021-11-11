using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Services.Interfaces;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using htmlWrapDemo;
using Shared.Models;

namespace Core
{
   public class DataService : IAllData
    {
        private readonly IDataScrapperRepository _dataScrapper;
        public DataService(IDataScrapperRepository dataScrapper)
        {
            _dataScrapper = dataScrapper;
        }
        public void BulknInsert(List<DataAccess.Models.Rate> rate)
        {
            _dataScrapper.BulknInsert(rate);
        }

       
    }
}
