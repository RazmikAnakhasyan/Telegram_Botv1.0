﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Models.Banks;
namespace Shared.Models.Rates
{
    public class RatesModel
    {
       public int ID { get; set; }
        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
        public decimal BuyValue { get; set; }
       public decimal SellValue { get; set; }
        public int BankId { get; set; }
       public DateTime LastUpdated { get; set; }
    }
}
