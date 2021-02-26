using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLRepository.Client.Contracts;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBotV2.Services;
using TelegramBotV2.Settings;

namespace TelegramBotV2.Controllers
{
    [Route("api/[controller]")]
    public class UpdateController : Controller
    {
        private readonly IUpdateService _updateService;
        private readonly IGrudgeApi _grudgeApi;
        private static TelegramBotClient _client;
        private readonly AppSettings _appSettings;
        public UpdateController(IUpdateService updateService, 
                                IGrudgeApi grudgeApi,
                                AppSettings appSettings)
        {
            _grudgeApi = grudgeApi;
            _updateService = updateService;
            _appSettings = appSettings;
        }

        [HttpGet]
        public string Index()
        {
            return "my telega bot :D";
        }

        // POST api/update
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Update update)
        {
            _client = new TelegramBotClient(_appSettings.BotConfiguration.BotToken);
            var text = update.Message.Text;
            switch (text)
            {
                case "show abusers":
                    var result = await _grudgeApi.GetAbuserAsync();
                    var answer = "";
                    foreach (var item in result)
                    {
                        answer += "abuser: " + item.AbuserName + " what's happened: " + item.Reason;
                        await _client.SendTextMessageAsync(update.Message.Chat.Id, answer);
                    }
                    break;
                default:
                    break;

            }
            return Ok();
        }
    }
}
