using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBotV2.Models.Commands
{
   public class HelloCommand : Command
    {
        public override string Name => "hello";
        public override async void ExecuteAsync(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;

            //todo locgic
            await client.SendTextMessageAsync(chatId, "hi su4ka", replyToMessageId: messageId);
        }
    }
}
