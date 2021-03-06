using Newtonsoft.Json;
using Shared.Model;
using Shared.Models;
using Shared.Models.Currency;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot
{
    public class TelegramCommandHandler
    {
        private readonly string _token;
        private readonly TelegramBotClient Bot;
        private readonly string _baseUrl;

        public TelegramCommandHandler()
        {
            Settings settings = JsonConvert.DeserializeObject<Settings>(System.IO.File.ReadAllText("settings.json"));
            _token = settings.Token;
            Bot = new TelegramBotClient(_token);
            _baseUrl = settings.BaseUrl;
        }

        [Obsolete]
        private async void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
            {
                try
                {
                    var pattern = @"(\d+)([A-Z]{3})([:]([A-Z]{3})){0,1}";
                    Regex regex = new Regex(pattern);
                    if (regex.IsMatch(e.Message.Text))
                    {

                        var match = regex.Match(e.Message.Text).Groups;
                        var from = match[2].Value;
                        var amount = double.Parse(match[1].Value);
                        var to = match[4].Value;
                        await Bot.SendTextMessageAsync(e.Message.Chat.Id, await BestChange(from, to, amount));
                        return;
                    }
                    switch (e.Message.Text)
                    {
                        case "/all":
                            await Bot.SendTextMessageAsync(e.Message.Chat.Id, await GetAll());
                            break;
                        case "/allBest":
                            await Bot.SendTextMessageAsync(e.Message.Chat.Id, await GetAllBest());
                            break;
                        case "/available":
                            await Bot.SendTextMessageAsync(e.Message.Chat.Id, await GetAvailable());
                            break;

                        default:
                            await Bot.SendTextMessageAsync(e.Message.Chat.Id, "Անհասկանալի հրաման, խնդրում ենք մուտքարգել հրամաններից որևիցե մեկը");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    await Bot.SendTextMessageAsync(e.Message.Chat.Id, ex.Message);
                }

            }
        }

        [Obsolete]
        public void Get()
        {
            Bot.OnMessage += Bot_OnMessage;
            Bot.StartReceiving();
            Console.ReadLine();
            Bot.StopReceiving();
        }

        public async Task<string> GetAllBest()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"{_baseUrl}/api/BestRates");
            string json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<IEnumerable<BestRateModel>>(json);
            var messageBuilder = new StringBuilder();
            foreach (var item in data)
            {
                messageBuilder.AppendLine(item.FromCurrency + item.FromCurrency.ToFlag());
                messageBuilder.AppendLine($"ԱՌՔ: {item.BuyValue:#.##} ({item.BestBankForBuying})");
                messageBuilder.AppendLine($"ՎԱՃԱՌՔ: {item.SellValue:#.##} ({item.BestBankForSelling})");
                messageBuilder.AppendLine($"Թարմացվել է` {item.LastUpdated:G}");
            }


            return messageBuilder.ToString();
        }
        public async Task<string> GetAll()
        {
            var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync($"{_baseUrl}/api/currency/all");
            string apiResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Rate>>(apiResponse).GroupBy(_ => _.BankId);
            var builder = new StringBuilder();
            foreach (var gr in result)
            {
                builder.AppendLine($"{gr.First().BankName}");
                foreach (var item in gr)
                {
                    builder.AppendLine($"{item.FromCurrency}{item.FromCurrency.ToFlag()} ➡️ {item.ToCurrency}{item.ToCurrency.ToFlag()}");
                    builder.AppendLine($"{item.BuyValue:#.##} |  {item.SellValue:#.##}");

                }
                builder.AppendLine($"Թարմացվել է` {gr.First().LastUpdated:G}");
                builder.AppendLine("--------------------------------------------");
            }
            return builder.ToString();

        }
        public async Task<string> GetAvailable()
        {
            var url = $"{_baseUrl}/api/currency/available";
            var client = new HttpClient();
            var response = await client.GetAsync(url);
            string responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<CurrencyModel>>(responseBody);
            var builder = new StringBuilder();
            foreach (var item in result)
            {
                builder.AppendLine(item.Code + "-" + item.Description);
            }
            return builder.ToString();
        }
        public async Task<string> BestChange(string from, string to, double amount)
        {
            var url = $"{_baseUrl}/api/convert/?from={from}&to={to}&amount={amount}";
            var client = new HttpClient();
            var response = await client.GetAsync(url);
            string responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<FromToConverter>(responseBody);

            var builder = new StringBuilder();
            builder.AppendLine($"Արժեք՝ {result.Value:N}{result.To} {result.To.ToFlag()}");
            builder.AppendLine("Բանկը՝ " + result.BestBank);
            builder.AppendLine($"Թարմացվել է` {result.LastUpdated:G}");
            return builder.ToString();
        }



    }
}
