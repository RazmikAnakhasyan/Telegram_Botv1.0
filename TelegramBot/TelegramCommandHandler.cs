using System;
using Telegram.Bot;

namespace TelegramBot
{
    public class TelegramCommandHandler
    {
        private static string _token = "2073841951:AAEwv5BcSBbG3X1VGyzkV-0dtjrCTVBWxqk";

        private static readonly TelegramBotClient Bot = new TelegramBotClient(_token);

        private static void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
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
