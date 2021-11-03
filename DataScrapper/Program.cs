﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace htmlWrapDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<IDataScrapper>();
            list.Add(new AmeriaBankDataScrapper());
            list.Add(new EvocaBankDataScrapper());
            list.Add(new AcbaBankDataScrapper());
            list.Add(new InceoBankDataScrapper());
            list.Add(new UniBankDataScrapper());
                // Console.WriteLine("Currency: {0} BuyValue: {1} SellValue: {2}", item.Currency, item.BuyValue, item.SellValue);
       

            foreach(var scrapper in list)
            {
                Console.WriteLine($"Getting data from  {scrapper.BankName}");
                try
                {
                    var data = scrapper.Get();
                    foreach (var item in data)
                    {
                        Console.WriteLine("Currency: {0} BuyValue: {1} SellValue: {2}", item.Currency, item.BuyValue, item.SellValue);
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Unable to get data from {scrapper.BankName}");
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine("Completed!");
            Console.ReadKey();

        }


    }
}