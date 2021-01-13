using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchDiscordBot.Util;

namespace TwitchDiscordBot
{
    class Bot
    {
        public static bool running;
        private DiscordSocketClient _client;
        public Bot()
        {
            Bootstrap bootstrap = new Bootstrap();
            BotLogger.Out("Initializing Bot...");

            if (!bootstrap.Boot())
                return;

            running = true;
        }

        public static async Task Core(string[] args)
        {
            var bot = new Bot();

            string Line = "";
            while (running)
            {
                await bot.Core();
                //Line = Console.ReadLine();
                //CommandManager?!
                //BotLogger.Out("Command: " + Line);
            }
            await bot.Disconnect();
            BotLogger.Out("Press any key to exit");
            Console.ReadKey();
        }

        public async Task Core()
        {
            _client = new DiscordSocketClient();
            _client.Log += Log;
            await _client.LoginAsync(TokenType.Bot, Bootstrap.Get().Config.Token);
            await _client.StartAsync();

            await Task.Delay(-1);
        }

        private Task Log(LogMessage msg)
        {
            BotLogger.Out(msg.ToString());
            return Task.CompletedTask;
        }

        public async Task Disconnect()
        {
            await _client.StopAsync();
        }


    }
}
