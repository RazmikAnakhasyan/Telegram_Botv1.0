using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using Telegram.Bot;

namespace TelegramBot
{
    public class TelegramCommandHandler
    {
        private readonly string _token;
        private readonly TelegramBotClient Bot;
        public TelegramCommandHandler(string Token)
        {
            Settings settings = JsonConvert.DeserializeObject<Settings>(File.ReadAllText("C:\\Users\\User\\source\\repos\\Telegram_Bot_API\\TelegramBot\\settings.json"));
            _token = settings.Token;
            Bot = new TelegramBotClient(_token);
        }

        [Obsolete]
        private async void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
            {
                if (e.Message.Text == "/AllBest")
                {
                    HttpClient client = new HttpClient();
                    HttpResponseMessage response = await client.GetAsync("https://localhost:44363/api/BestRates/best/BestRates");
                    await Bot.SendTextMessageAsync(e.Message.Chat.Id, responsemessage);
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

    }
}
