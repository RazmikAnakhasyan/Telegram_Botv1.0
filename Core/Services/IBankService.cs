using DataAccess.Models;
using Shared.Models.Banks;
using Shared.Models.Rates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public  interface IBankService
    {
       public IEnumerable<RatesInfoModel> AllRates();
    }
}
