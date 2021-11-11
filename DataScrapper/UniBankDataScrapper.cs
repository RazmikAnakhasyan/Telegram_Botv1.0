using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace htmlWrapDemo
{
    public class UniBankDataScrapper : IDataScrapper
    {
        public int Id => 5;

        public IEnumerable<CurrencyModel> Get()
        {
            var client = new HttpClient();
            var html = client.GetStringAsync("https://www.unibank.am/hy/")
                .GetAwaiter()
                .GetResult();

            //var html = File.ReadAllText("test.html");
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            var nodes = doc.DocumentNode.SelectNodes("/html/body/div/div[2]/section[1]/div/div/div/div[2]/div[1]/div[1]/ul[2]/li")
                .AsEnumerable();
            List<CurrencyModel> models = new List<CurrencyModel>();
            while (nodes.GetEnumerator().MoveNext())
            {
                var model = new CurrencyModel();
                
                model.Currency = nodes.ElementAt(0).InnerText.Trim();
                model.BuyValue = decimal.Parse(nodes.ElementAt(1).InnerText.Trim());
                model.SellValue = decimal.Parse(nodes.ElementAt(2).InnerText.Trim());
                model.BankId = Id;
                models.Add(model);
                nodes = nodes.Skip(3);
            }
         
            return models;
        }
    
    }
}
