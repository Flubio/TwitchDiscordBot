using System;
using System.Threading.Tasks;
using TwitchDiscordBot.Util;

namespace TwitchDiscordBot
{
    class Program
    {
        public static bool running;

        public static Task Main(string[] args)
            => Bot.Core(args);
            
        /*static void Main(string[] args)
        {
            Bootstrap bootstrap = new Bootstrap();
            BotLogger.Out("Initializing Bot...");

            if (!bootstrap.Boot())
                return;

            running = true;

            string Line = "";
            while (running)
            {
                Line = Console.ReadLine();
                //CommandManager?!
                BotLogger.Out("Command: " + Line);
            }

            BotLogger.Out("Press any key to exit");
            Console.ReadKey();
        }*/
    }
}
