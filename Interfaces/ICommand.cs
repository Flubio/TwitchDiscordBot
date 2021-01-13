using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchDiscordBot.Commands
{
    interface ICommand
    {
        string Name { get; }
        string[] Args { get; }
        void Execute(string[] args);
    }
}
