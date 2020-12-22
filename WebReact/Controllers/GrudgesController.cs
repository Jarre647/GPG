﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SQL_Repository.Models;
using SQL_Repository.Services.Contracts;

namespace WebReact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrudgesController : ControllerBase
    {
        private readonly IGrudgesApi _grudgesApi;

        public GrudgesController(IGrudgesApi grudgesApi)
        {
            _grudgesApi = grudgesApi;
        }

        [HttpGet]
        public async Task<List<Grudge>> GetGrudges()
        {
            return await _grudgesApi.GetGrudgesAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AddGrudge(Grudge grudge)
        {
            await _grudgesApi.PostGrudgeAsync(grudge);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGrudge(Grudge grudge)
        {
            await _grudgesApi.PutGrudgeAsync(grudge);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteGrudge(int id)
        {
            await _grudgesApi.DeleteGrudgeAsync(id);
            return Ok();
        }
    }
}
