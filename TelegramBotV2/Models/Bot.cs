using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using SQL_Repository.Settings;
using Telegram.Bot;
using TelegramBotV2.Models.Commands;

namespace TelegramBotV2.Models
{
    public class Bot
    {
        private static TelegramBotClient client;

        private static List<Command> commandList;
        public static IReadOnlyList<Command> Commands
        {
            get => commandList.AsReadOnly();
        }

        public static async Task<TelegramBotClient> Get(IOptions<BotConfiguration> configuration)
        {
            if (client != null)
            {
                return client;
            }
            commandList = new List<Command> { new HelloCommand()};

            //todo add more commands

            client = new TelegramBotClient(configuration.Value.BotToken);
           

            await client.SetWebhookAsync("https://ddebf1a7c97a.ngrok.io/api/update");

            return client;
        }
    }
}
