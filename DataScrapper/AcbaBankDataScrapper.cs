using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace htmlWrapDemo
{
    public class AcbaBankDataScrapper : IDataScrapper
    {

        public int Id => 1;

        public IEnumerable<CurrencyModel> Get()
        {
            var client = new HttpClient();
            var html = client.GetStringAsync("https://www.acba.am/en")
                .GetAwaiter()
                .GetResult();

            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            var nodes = doc.DocumentNode.SelectNodes("//div[@class='simple_price-row']").Skip(1);
                
            List<CurrencyModel> models = new List<CurrencyModel>();
            foreach (var item in nodes)
            {
                var childs = item.ChildNodes.Where(_ => _.Name == "div").ToArray();

                try
                {

                    var model = new CurrencyModel();
                    model.Currency = childs[0].InnerText.Trim();
                    model.BuyValue = decimal.Parse(childs[1].InnerText.Trim());
                    model.SellValue = decimal.Parse(childs[2].InnerText.Trim());
                    model.BankId = Id;
                    models.Add(model);
                }
                catch { }

            }
            return models;
        }
    }
}
