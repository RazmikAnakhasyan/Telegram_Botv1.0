using AutoMapper;
using Core.Model;
using Core.Services.Interfaces;
using DataAccess.Entities;
using DataAccess.Repositaries.Interfaces;
using System.Collections.Generic;

namespace Core.Services.Services
{
    public class BestRates : IBestRates
    {
        private readonly IBestRatesRepository _bestRates;
        private readonly IMapper _mapper;
        public BestRates(IBestRatesRepository bestRates, IMapper mapper)
        {
            _bestRates = bestRates;
            _mapper = mapper;
        }
        public List<CurrencyRate> GetBestRates()
        {
            List<Rate> rates = _bestRates.GetBestRates();
            return _mapper.Map<List<CurrencyRate>>(rates);
        }
    }
}
