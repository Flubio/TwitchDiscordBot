using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchDiscordBot.Util
{
    class BotLogger
    {
        public static void Out(string msg) => Info(msg);
        public static void Out(string msg, object arg0) => Info(string.Format(msg, arg0));
        public static void Out(string msg, object arg0, object arg1) => Info(string.Format(msg, arg0, arg1));
        public static void Out(string msg, params object[] args) => Info(string.Format(msg, args));

        public static void Error(string msg) => Write("[Error] " + msg);
        public static void Error(string msg, object arg0) => Write("[Error] " + string.Format(msg, arg0));
        public static void Error(string msg, object arg0, object arg1) => Write("[Error] " + string.Format(msg, arg0, arg1));
        public static void Error(string msg, params object[] args) => Write("[Error] " + string.Format(msg, args));

        public static void Warning(string msg) => Write("[Warning] " + msg);
        public static void Warning(string msg, object arg0) => Write("[Warning] " + string.Format(msg, arg0));
        public static void Warning(string msg, object arg0, object arg1) => Write("[Warning] " + string.Format(msg, arg0, arg1));
        public static void Warning(string msg, params object[] args) => Write("[Warning] " + string.Format(msg, args));

        public static void Info(string msg) => Write("[Info] " + msg);
        public static void Info(string msg, object arg0) => Write("[Info] " + string.Format(msg, arg0)); 
        public static void Info(string msg, object arg0, object arg1) => Write("[Info] " + string.Format(msg, arg0, arg1));
        public static void Info(string msg, params object[] args) => Write("[Info] " + string.Format(msg, args));


        public static void Write(string message) => Console.WriteLine(DateTime.Now.ToString("H:mm:ss ") + message);
    }
}
