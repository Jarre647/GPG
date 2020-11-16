using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQL_Repository.Models;
using SQL_Repository.Services.Contracts;

namespace Web.Controllers
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
        public async Task<List<Grudge>> GetAbuser()
        {
            return await _grudgesApi.GetGrudgesAsync();
        }
    }
}
