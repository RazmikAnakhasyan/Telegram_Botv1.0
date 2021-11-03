using AutoMapper;
using Core.Services.Interfaces;
using DataAccess.Repositaries.Interfaces;
using Shared.Models;
using System.Collections.Generic;

namespace Core.Services.Services
{
    public class BestRateService : IBestRateService
    {
        private readonly IBestRatesRepository _bestRates;
        private readonly IMapper _mapper;
        public BestRateService(IBestRatesRepository bestRates, IMapper mapper)
        {
            _bestRates = bestRates;
            _mapper = mapper;
        }
        public IEnumerable<BestRateModel> GetBestRates()
        {
            var rates = _bestRates.GetBestRates();
            return rates;
        }
    }
}
