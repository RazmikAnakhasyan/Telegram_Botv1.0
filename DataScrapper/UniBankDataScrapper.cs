using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace htmlWrapDemo
{
    public class UniBankDataScrapper : IDataScrapper
    {
        public string BankName => "UNIBANK";

        public IEnumerable<CurrencyModel> Get()
        {
            var client = new HttpClient();
            var html = client.GetStringAsync("https://www.unibank.am/hy/")
                .GetAwaiter()
                .GetResult();

            //var html = File.ReadAllText("test.html");
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            var nodes = doc.DocumentNode.SelectNodes("/html/body/div/div[2]/section[1]/div/div/div/div[2]/div[1]/div[1]/ul[2]").ToArray();
            List<CurrencyModel> models = new List<CurrencyModel>();
            foreach (var item in nodes)
            {
                var tds = item.SelectNodes("li").ToArray();
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
