using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 


 namespace DataAccess.Repositories
{
    public interface IBestAvailableRateRepository
    {
        public List<Rate> AvailableRates();
        public string GetBankName(int bankID);
    }
}
