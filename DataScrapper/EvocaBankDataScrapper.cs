using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace htmlWrapDemo
{
    public class EvocaBankDataScrapper : IDataScrapper
    {
        public int id=> 3;

        public IEnumerable<CurrencyModel> Get()
        {
            var client = new HttpClient();
            var html = client.GetStringAsync("https://www.evoca.am/")
                .GetAwaiter()
                .GetResult();

            //var html = File.ReadAllText("test.html");
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            var nodes = doc.DocumentNode.SelectNodes("/html/body/main/div[9]/div/div[1]/div/div[1]/div/div[1]/div/div[1]/div/div/table/tbody/tr").ToArray();
            List<CurrencyModel> models = new List<CurrencyModel>();
            foreach(var item in nodes)
            {
                var tds = item.SelectNodes("td").Take(3).ToArray();
                
                try
                {

                    var model = new CurrencyModel();
                    model.Currency = tds[0].InnerText.Trim();
                    model.BuyValue = decimal.Parse(tds[1].InnerText.Trim());
                    model.SellValue = decimal.Parse(tds[2].InnerText.Trim());

                    models.Add(model);
                }
                catch { }
             
            }
            return models;
        }
    }
}
