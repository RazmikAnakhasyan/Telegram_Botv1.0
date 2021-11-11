using Core;
using DataAccess.Models;
using DataAccess.Repositories.Implementation;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace htmlWrapDemo
{
   public class DataScrapper
    {
        private static List<IDataScrapper> list;
        
        
        static void Main(string[] args)
        {
            var _baseCurrency = JObject.Parse(File.ReadAllText("appsettings.json"))["Configs"]["BaseCurrency"]
                .Value<string>();

            list = new List<IDataScrapper>();
            list.Add(new AmeriaBankDataScrapper());
            list.Add(new EvocaBankDataScrapper());
            list.Add(new AcbaBankDataScrapper());
            list.Add(new InceoBankDataScrapper());
            list.Add(new UniBankDataScrapper());
            // Console.WriteLine("Currency: {0} BuyValue: {1} SellValue: {2}", item.Currency, item.BuyValue, item.SellValue);

            var all = new List<CurrencyModel>();
            
            foreach(var scrapper in list)
            {
                Console.WriteLine($"Getting data from  {scrapper.Id}");
                try
                {
                    var data = scrapper.Get();
                    all.AddRange(data);
                    foreach (var item in data)
                    {
                        Console.WriteLine("Currency: {0} BuyValue: {1} SellValue: {2}", item.Currency, item.BuyValue, item.SellValue);
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Unable to get data from {scrapper.Id}");
                    Console.WriteLine(ex.Message);
                }
            }

            var _service = new RateService(new RatesRepository(new DbModel()));
            _service.BulknInsert(all.Select(_ => new Rate
            {
                BankId = _.BankId,
                BuyValue = _.BuyValue,
                SellValue = _.SellValue,
                FromCurrency = _.Currency == "RUR" ? "RUB" : _.Currency,
                ToCurrency = _baseCurrency
            }));
            Console.WriteLine("Completed!");
            Console.ReadKey(); 

        }


    }
}
