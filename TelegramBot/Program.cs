using Newtonsoft.Json;
using System;
using System.IO;

namespace TelegramBot
{
    class Program
    {
        [Obsolete]
        static void Main(string[] args)
        {
            TelegramCommandHandler telegram = new TelegramCommandHandler();
            telegram.Get();
        }
    }
}
