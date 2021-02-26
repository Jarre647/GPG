using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQL_Repository.Services.Contracts;
using SQLRepository.Client.Models;

namespace SQL_Repository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrudgesController : ControllerBase
    {
        private readonly IGrudgesApi _grudgesApi;

        public GrudgesController(
            IGrudgesApi grudgesApi)
        {
            _grudgesApi = grudgesApi;
        }

        // GET: api/Grudges
        [HttpGet]
        public async Task<List<GrudgeModel>> GetAbuserAsync()
        {
            return await _grudgesApi.GetGrudgesAsync();
        }

        // GET: api/Grudges/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GrudgeModel>> GetGrudgeByIdAsync(int id)
        {
            var grudge = await _grudgesApi.GetGrudgeByIdAsync(id);

            if (grudge == null)
            {
                return NotFound();
            }

            return Ok(grudge);
        }

        // PUT: api/Grudges/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrudgeAsync(GrudgeModel grudge)
        {
            if (grudge.Id != 0) //todo настроить нормально обработку ошибок
            {
                return BadRequest();
            }

            try
            {
                await _grudgesApi.PutGrudgeAsync(grudge);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Grudges
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GrudgeModel>> PostGrudgeAsync(GrudgeModel grudge)
        {
            try
            {
                await _grudgesApi.PostGrudgeAsync(grudge);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return Ok();
        }

        // DELETE: api/Grudges/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GrudgeModel>> DeleteGrudge(int id)
        {
            try
            {
                await _grudgesApi.DeleteGrudgeAsync(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return Ok();
        }
    }
}
