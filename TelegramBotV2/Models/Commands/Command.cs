using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBotV2.Models.Commands
{
    public abstract class Command
    {
        public abstract string Name { get; }
        public abstract void ExecuteAsync(Message message, TelegramBotClient client);

        public bool Contains(string command, IOptions<BotConfiguration> configuration)
        {
            return command.Contains(this.Name) && command.Contains(configuration.Value.Name);
        }
    }
}
