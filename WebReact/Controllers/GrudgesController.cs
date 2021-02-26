using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SQLRepository.Client.Contracts;


namespace WebReact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrudgesController : ControllerBase
    {
        private readonly IGrudgeApi _grudgesApi;

        public GrudgesController(IGrudgeApi grudgesApi)
        {
            _grudgesApi = grudgesApi;
        }

        [HttpGet]
        public async Task GetGrudges()
        {
            var test = await _grudgesApi.GetAbuserAsync();

            return;
        }

        ////[HttpPost]
        ////public async Task<IActionResult> AddGrudge(Grudge grudge)
        ////{
        ////    await _grudgesApi.PostGrudgeAsync(grudge);
        ////    return Ok();
        ////}

        ////[HttpPut]
        ////public async Task<IActionResult> UpdateGrudge(Grudge grudge)
        ////{
        ////    await _grudgesApi.PutGrudgeAsync(grudge);
        ////    return Ok();
        ////}

        //[HttpDelete]
        //public async Task<IActionResult> DeleteGrudge(int id)
        //{
        //    await _grudgesApi.DeleteGrudgeAsync(id);
        //    return Ok();
        //}
    }
}
