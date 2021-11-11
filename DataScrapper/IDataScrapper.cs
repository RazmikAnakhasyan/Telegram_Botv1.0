using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace htmlWrapDemo
{
    public interface IDataScrapper
    {
        IEnumerable<CurrencyModel> Get();

        int Id { get; }
    }

}
