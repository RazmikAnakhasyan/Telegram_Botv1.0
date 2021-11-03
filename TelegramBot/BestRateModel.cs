using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot
{
    public class BestRateModel
    {
        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
        public string BestBankForBuying { get; set; }
        public string BestBankForSelling { get; set; }
        public decimal BuyValue { get; set; }
        public decimal SellValue { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
