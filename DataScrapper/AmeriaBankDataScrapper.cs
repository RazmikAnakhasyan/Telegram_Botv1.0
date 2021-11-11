using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace htmlWrapDemo
{
    public class AmeriaBankDataScrapper : IDataScrapper
    {
        public int Id => 2;

        public IEnumerable<CurrencyModel> Get()
        {
            var client = new HttpClient();
            var html = client.GetStringAsync("https://ameriabank.am/")
                .GetAwaiter()
                .GetResult();

            //var html = File.ReadAllText("test.html");
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            var node = doc.DocumentNode.SelectNodes(@"//table[@id='dnn_ctr16862_View_grdRates']//tr")
                .Skip(2).ToArray();
            List<CurrencyModel> models = new List<CurrencyModel>();

            foreach (var item in node)
            {
                var tds = item.SelectNodes("td").Take(3).ToArray();
                try
                {
                    var model = new CurrencyModel();
                    model.Currency = tds[0].InnerText;
                    model.BuyValue = decimal.Parse(tds[1].InnerText);
                    model.SellValue = decimal.Parse(tds[2].InnerText);
                    model.BankId = Id;
                    models.Add(model);
                }
                catch { }
            }
            return models;

        }
    }
}
