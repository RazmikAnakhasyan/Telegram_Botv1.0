using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using Shared.Models;
using DataAccess.Repositories;
using AutoMapper;

namespace Core.Services
{
    class BestAvailableRateService : IBestAvailableRateService
    {
        private readonly IBestAvailableRateRepository _bestAvailableRateRepository;
        public BestAvailableRateService(IBestAvailableRateRepository bestAvailableRateRepository)
        {
            _bestAvailableRateRepository = bestAvailableRateRepository;
        }

         public BestAvailableRate GetBestAvailableRate(string fromCurrency, string toCurrency, decimal amount)
        {
            BestAvailableRate bestRate=new BestAvailableRate();
            Rate r = new Rate();
           
            List <Rate > availableRates =  _bestAvailableRateRepository.AvailableRates();
            if (fromCurrency == "AMD")
            {
    
               r = availableRates.First(_ => _.FromCurrency == toCurrency     
                                                && _.SellValue ==availableRates.Where(_ => _.FromCurrency == toCurrency).OrderBy(_ => _.SellValue).FirstOrDefault().SellValue);

                bestRate.BankName = _bestAvailableRateRepository.GetBankName(r.BankId);
                bestRate.Amount =Math.Round( amount / r.SellValue,2) ;
            }
            else if (toCurrency == "AMD")
            {
                r = availableRates.First(_ => _.FromCurrency == fromCurrency
                                                   && _.BuyValue == availableRates.Where(_ => _.FromCurrency == fromCurrency).OrderByDescending(_ => _.BuyValue ).FirstOrDefault().BuyValue);

                bestRate.BankName = _bestAvailableRateRepository.GetBankName(r.BankId);
                bestRate.Amount = Math.Round(amount * r.BuyValue, 2);
            }
            else
            {

                                //todo

                r = availableRates.OrderByDescending(_ => _.BuyValue / _.SellValue).FirstOrDefault();
                bestRate.BankName = _bestAvailableRateRepository.GetBankName(r.BankId);
                bestRate.Amount = Math.Round(amount * r.BuyValue, 2);

            }

            return bestRate;
        }

    
    }
}
