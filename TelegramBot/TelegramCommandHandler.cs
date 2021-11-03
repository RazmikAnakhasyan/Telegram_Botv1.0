using Newtonsoft.Json;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace TelegramBot
{
    public class TelegramCommandHandler
    {
        private readonly string _token;
        private readonly TelegramBotClient Bot;
        private readonly string _baseUrl;

        public TelegramCommandHandler()
        {
            Settings settings = JsonConvert.DeserializeObject<Settings>(File.ReadAllText("settings.json"));
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
                    switch (e.Message.Text)
                    {
                        case "all":
                            await Bot.SendTextMessageAsync(e.Message.Chat.Id, await GetAll());
                            break;
                        case "/AllBest":
                            await Bot.SendTextMessageAsync(e.Message.Chat.Id, await GetAllBest());
                            break;
                        case "/Available":
                            await Bot.SendTextMessageAsync(e.Message.Chat.Id, await GetAvailable());
                            break;
                        //case "availableBanks":
                        //    {
                        //        using var response = await HttpClient.GetAsync("https://localhost:44363/api/currency/availableBanks");
                        //        string apiResponse = await response.Content.ReadAsStringAsync();
                        //        List<Rate> result = JsonConvert.DeserializeObject<List<Rate>>(apiResponse);
                        //        await Bot.SendTextMessageAsync(e.Message.Chat.Id, apiResponse);
                        //    }
                        //    break;
                        default:
                            await Bot.SendTextMessageAsync(e.Message.Chat.Id, "Command not handled");
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
                messageBuilder.AppendLine(item.FromCurrency);
                messageBuilder.AppendLine($"ԱՌՔ:{item.BuyValue} ({item.BestBankForBuying})");
                messageBuilder.AppendLine($"ՎԱՃԱՌՔ  : {item.SellValue} ({item.BestBankForSelling})");
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
                    builder.AppendLine($"{item.FromCurrency}:{item.ToCurrency}");
                    builder.AppendLine($"{item.BuyValue}:{item.SellValue}");

                }
                builder.AppendLine($"Թարմացվել է: {gr.First().LastUpdated.ToShortDateString()}");
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
            return responseBody.ToString();
        }

    }
}
