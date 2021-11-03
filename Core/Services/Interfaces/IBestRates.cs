using DataAccess.Models;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface IBestRateService
    {
        IEnumerable<BestRateModel> GetBestRates();
    }
}
