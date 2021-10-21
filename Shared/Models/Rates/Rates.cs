using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Rates
{
    class Rates
    {
        int ID { get; set; }
        string FromCurrency { get; set; }
        string ToCurrency { get; set; }
        decimal BuyValue { get; set; }
        decimal SellValue { get; set; }
        int BankId { get; set; }
        DateTime LastUptade { get; set; }
    }
}
