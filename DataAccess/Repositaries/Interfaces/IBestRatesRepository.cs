using System.Collections.Generic;
using DataAccess.Entities;
namespace DataAccess.Repositaries.Interfaces
{
    public interface IBestRatesRepository
    {
        List<Rate> GetBestRates();
    }
}
