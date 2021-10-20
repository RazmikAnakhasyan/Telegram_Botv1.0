using System;

namespace TelegramBot
{
    class Program
    {
        static void Main(string[] args)
        {
            TelegramCommandHandler telegram = new TelegramCommandHandler();
            telegram.Get();
        }
    }
}
