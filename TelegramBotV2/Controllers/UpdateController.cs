using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQL_Repository.Services.Contracts;
using Telegram.Bot.Types;
using TelegramBotV2.Services;

namespace TelegramBotV2.Controllers
{
    [Route("api/[controller]")]
    public class UpdateController : Controller
    {
        private readonly IUpdateService _updateService;

        public UpdateController(IUpdateService updateService)
        {
            _updateService = updateService;
        }
        [HttpGet]
        public string Index()
        {
            return "my telega bot";
        }

        // POST api/update
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Update update)
        {
            var test = update.Message.Text;
            await _updateService.EchoAsync(update);

            return Ok();
        }
    }
}
