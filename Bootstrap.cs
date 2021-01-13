using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TwitchDiscordBot.Util;

namespace TwitchDiscordBot
{
    class Bootstrap
    {
        private static Bootstrap instance;
        public static volatile bool running = true;
        public static volatile bool killed = false;
        public Config Config { get; }


        public Bootstrap()
        {
            instance = this;
            Config = new Config();
            Config.Load();
        }

        public bool Boot()
        {
            AppDomain.CurrentDomain.ProcessExit += ShutdownHook;
            
            //eom
            return true;
        }


        private void ShutdownHook(object o, EventArgs e)
        {
            killed = true;

        }

        public void Shutdown()
        {
            if (!running)
                return;
            //Log shutdown message
            BotLogger.Out("Stopping Discord Bot! ");

            running = false;

            Thread.Sleep(1000);

            Bot.running = false;
            
        }

        public static Bootstrap Get() => instance;
    }
}
