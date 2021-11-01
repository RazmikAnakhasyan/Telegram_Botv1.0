
using Shared.Model;
using System;
using System.Collections.Generic;

namespace Core.Services.Interfaces
{
    public interface ICurrencies
    {
        List<CurrenciesConvertDetails> GetConvertInfoForAllCurrencies(string currency, Double exchangedValue);
    }
}
