using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace htmlWrapDemo
{
    public class AcbaBankDataScrapper : IDataScrapper
    {
        public string BankName => "ACBA";

        public IEnumerable<CurrencyModel> Get()
        {
            var client = new HttpClient();
            var html = client.GetStringAsync("https://www.acba.am")
                .GetAwaiter()
                .GetResult();

            //var html = File.ReadAllText("test.html");
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            var nodes = doc.DocumentNode.SelectNodes("/html/body/div/div/main/div[3]/div[1]/div/div[2]/div[2]/div/div[2]/div/div[2]").ToArray();
            List<CurrencyModel> models = new List<CurrencyModel>();
            foreach (var item in nodes)
            {
                var tds = item.SelectNodes("div").Take(3).ToArray();

                try
                {

                    var model = new CurrencyModel();
                    model.Currency = tds[0].InnerText.Replace("\n","").Replace("\t","");
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
