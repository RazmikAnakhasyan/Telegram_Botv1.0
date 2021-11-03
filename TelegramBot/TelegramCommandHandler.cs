using Newtonsoft.Json;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Telegram.Bot;

namespace TelegramBot
{
    public class TelegramCommandHandler
    {
        private readonly string _token;
        private readonly TelegramBotClient Bot;
        private static readonly HttpClient HttpClient;
        static TelegramCommandHandler()
        {
            HttpClient = new HttpClient();
        }

        public TelegramCommandHandler()
        {
            Settings settings = JsonConvert.DeserializeObject<Settings>(File.ReadAllText("settings.json"));
            _token = settings.Token;
            Bot = new TelegramBotClient(_token);
        }

        [Obsolete]
        private async void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
            {
                switch (e.Message.Text)
                {
                    case "all":
                        {
                            using var response = await HttpClient.GetAsync("https://localhost:44363/api/currency/all");
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            List<Rate> result = JsonConvert.DeserializeObject<List<Rate>>(apiResponse);
                            await Bot.SendTextMessageAsync(e.Message.Chat.Id, apiResponse);
                        }
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
                        await Bot.SendTextMessageAsync(e.Message.Chat.Id, e.Message.Text);
                        break;
                }
              
            }
        }

        [Obsolete]
        public void Get()
        {
            Bot.OnMessage +=  Bot_OnMessage;
            Bot.StartReceiving();
            Console.ReadLine();
            Bot.StopReceiving();
        }

    }
}
