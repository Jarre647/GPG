using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQL_Repository.Data;
using SQL_Repository.Models;
using SQL_Repository.Repositories;
using SQL_Repository.Services.Contracts;

namespace SQL_Repository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrudgesController : ControllerBase
    {
        private readonly SqlRepositoryContext _context;
        private readonly IGrudgesApi _grudgesApi;

        public GrudgesController(
            SqlRepositoryContext context,
            IGrudgesApi grudgesApi)
        {
            _context = context;
            _grudgesApi = grudgesApi;
        }

        // GET: api/Grudges
        [HttpGet]
        public async Task<List<Grudge>> GetAbuser()
        {
            return await _grudgesApi.GetGrudges();
        }

        // GET: api/Grudges/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Grudge>> GetGrudgeById(int id)
        {
            var grudge = await _grudgesApi.GetGrudgeById(id);

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
        public async Task<IActionResult> PutAbuser(int id, Grudge grudge)
        {
            if (id != grudge.Id)
            {
                return BadRequest();
            }

            _context.Entry(grudge).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AbuserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Grudges
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Grudge>> PostAbuser(Grudge grudge)
        {
            grudge.Date = DateTime.Now;
            _context.Grudge.Add(grudge);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAbuser", new { id = grudge.Id }, grudge);
        }

        // DELETE: api/Grudges/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Grudge>> DeleteAbuser(int id)
        {
            var abuser = await _context.Grudge.FindAsync(id);
            if (abuser == null)
            {
                return NotFound();
            }

            _context.Grudge.Remove(abuser);
            await _context.SaveChangesAsync();

            return abuser;
        }

        private bool AbuserExists(int id)
        {
            return _context.Grudge.Any(e => e.Id == id);
        }
    }
}
