using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repositories;
using DataAccess.Models;
using Shared.Models;

namespace Core.Services
{
    public interface IBestAvailableRateService

    {
        public BestAvailableRate GetBestAvailableRate(string fromCurrency, string toCurrency, decimal amount);
    }
}
