using System.Collections.Generic;
using DataAccess.Models;
using Shared.Models;

namespace DataAccess.Repositaries.Interfaces
{
    public interface IBestRatesRepository
    {
        IEnumerable<BestRateModel> GetBestRates();
    }
}
