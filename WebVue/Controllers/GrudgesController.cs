using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SQLRepository.Client.Contracts;
using SQLRepository.Client.Models;

namespace WebVue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GrudgesController : ControllerBase
    {
        private readonly IGrudgeApi _grudgeApi;

        public GrudgesController(IGrudgeApi grudgeApi)
        {
            _grudgeApi = grudgeApi;
        }

        [HttpGet]
        public async Task<IReadOnlyList<GrudgeModel>> GetGrudges()
        {
            return await _grudgeApi.GetAbuserAsync();
        }

        [HttpPost]
        public async Task<IActionResult> PostGrudges(GrudgeModel grudge)
        {
            try
            {
                await _grudgeApi.PutGrudgeAsync(grudge);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }

        }
    }
}
