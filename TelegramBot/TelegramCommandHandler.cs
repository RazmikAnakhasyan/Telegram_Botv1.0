using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
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
                if (e.Message.Text == "/AllBest")
                {
                    await Bot.SendTextMessageAsync(e.Message.Chat.Id, GetAllBest());
                }
                else
                {
                    await Bot.SendTextMessageAsync(e.Message.Chat.Id, "UnHandled Command!!!");
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

        public string GetAllBest()
        {
            //HttpClient client = new HttpClient();
            //HttpResponseMessage response = await client.GetAsync($"{_baseUrl}/api/BestRates");
            //string responsemessage = await response.Content.ReadAsStringAsync();
            var mockJson = File.ReadAllText("mocks/allbest-mock.json");
            var data = JsonConvert.DeserializeObject<IEnumerable<CurrencyRate>>(mockJson);
            var messageBuilder = new StringBuilder();
            foreach(var item in data)
            {
                messageBuilder.AppendLine($"{item.BaseCurrency} : {item.Rates.Buy} - {item.Rates.Sell}");
            }

            return messageBuilder.ToString();
        }

    }
}
