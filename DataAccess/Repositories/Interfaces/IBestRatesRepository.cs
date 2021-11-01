using System.Collections.Generic;
using DataAccess.Models;
namespace DataAccess.Repositaries.Interfaces
{
    public interface IBestRatesRepository
    {
        List<Rate> GetBestRates();
    }
}
