using Telegram.Bot;

namespace TelegramBotV2.Services
{
    public interface IBotService
    {
        TelegramBotClient Client { get; }
    }
}
