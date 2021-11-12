using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot
{
     public static class FlagCurrencyMapper
    {
        private static Dictionary<string, string> FlagToCurrency = new Dictionary<string, string>
        {
            {"AMD", "🇦🇲" },
            {"USD", "🇺🇸" },
            {"EUR", "🇪🇺" },
            {"RUB", "🇷🇺" },
            {"GBP", "🇬🇧" }
        };

        public static string ToFlag(this string currency)
        {
            return FlagToCurrency.ContainsKey(currency) ? FlagToCurrency[currency] : string.Empty;
        }
    }
}
