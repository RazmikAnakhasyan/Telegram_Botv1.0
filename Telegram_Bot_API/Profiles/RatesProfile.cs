using AutoMapper;
using Core.Model;
using DataAccess.Models;

namespace API.Profiles
{
    public class RatesProfile:Profile
    {
        public  RatesProfile()
        {

            CreateMap<Rate, CurrencyRate>()
                .ForPath(dest => dest.Rates.Buy, source => source.MapFrom(_ => _.BuyValue))
                .ForPath(dest => dest.Rates.Sell, source => source.MapFrom(_ => _.SellValue))
                .ForPath(dest => dest.BaseCurrency, source => source.MapFrom(_ => _.ToCurrency));
        }
    }
}

