using Newtonsoft.Json;
using System;
using System.IO;
using Telegram.Bot;

namespace TelegramBot
{
    public class TelegramCommandHandler
    {
        private readonly string _token;
        private readonly TelegramBotClient Bot;
        public TelegramCommandHandler()
        {
            Settings settings = JsonConvert.DeserializeObject<Settings>(File.ReadAllText("settings.json"));
            _token = settings.Token;
            Bot = new TelegramBotClient(_token);
        }


        private void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
            {
                Bot.SendTextMessageAsync(e.Message.Chat.Id, e.Message.Text);
            }
        }
        public void Get()
        {
            Bot.OnMessage += Bot_OnMessage;
            Bot.StartReceiving();
            Console.ReadLine();
            Bot.StopReceiving();
        }

    }
}
