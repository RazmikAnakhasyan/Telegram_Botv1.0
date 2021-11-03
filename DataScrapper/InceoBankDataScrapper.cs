using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace htmlWrapDemo
{
    public class InceoBankDataScrapper : IDataScrapper
    {
        public string BankName => "INECO";

        public IEnumerable<CurrencyModel> Get()
        {
            var client = new HttpClient();
            var html = client.GetStringAsync("https://www.inecobank.am")
                .GetAwaiter()
                .GetResult();

            //var html = File.ReadAllText("test.html");
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            var nodes = doc.DocumentNode.SelectNodes("//*[@id='root']/div/main/div[3]/div[1]/div/div[2]/div[2]/div/div[2]/div").ToArray();
            List<CurrencyModel> models = new List<CurrencyModel>();
            foreach (var item in nodes)
            {
                var tds = item.SelectNodes("div").ToArray();

                try
                {

                    var model = new CurrencyModel();
                    model.Currency = tds[0].InnerText;
                    model.BuyValue = decimal.Parse(tds[1].InnerText);
                    model.SellValue = decimal.Parse(tds[2].InnerText);

                    models.Add(model);
                }
                catch { }

            }
            return models;
        }
    }
}
