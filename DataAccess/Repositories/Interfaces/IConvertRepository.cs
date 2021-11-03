using Shared.Model;
using System;
using System.Collections.Generic;

namespace DataAccess.Repositaries.Interfaces
{
    public interface IConvertRepository
    {
        List<CurrenciesConvertDetails> GetConvertDetails(string Currency, Double exchangedValue);
        CurrenciesConvertDetails Convert(string from, string to, decimal amount);
    }
}
