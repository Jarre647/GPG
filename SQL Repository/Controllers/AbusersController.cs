using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQL_Repository.Data;
using SQL_Repository.Models;

namespace SQL_Repository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbusersController : ControllerBase
    {
        private readonly SQL_RepositoryContext _context;

        public AbusersController(SQL_RepositoryContext context)
        {
            _context = context;
        }

        // GET: api/Abusers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Abuser>>> GetAbuser()
        {
            return await _context.Abuser.ToListAsync();
        }

        // GET: api/Abusers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Abuser>> GetAbuser(int id)
        {
            var abuser = await _context.Abuser.FindAsync(id);

            if (abuser == null)
            {
                return NotFound();
            }

            return abuser;
        }

        // PUT: api/Abusers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAbuser(int id, Abuser abuser)
        {
            if (id != abuser.Id)
            {
                return BadRequest();
            }

            _context.Entry(abuser).State = EntityState.Modified;

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

        // POST: api/Abusers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Abuser>> PostAbuser(Abuser abuser)
        {
            _context.Abuser.Add(abuser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAbuser", new { id = abuser.Id }, abuser);
        }

        // DELETE: api/Abusers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Abuser>> DeleteAbuser(int id)
        {
            var abuser = await _context.Abuser.FindAsync(id);
            if (abuser == null)
            {
                return NotFound();
            }

            _context.Abuser.Remove(abuser);
            await _context.SaveChangesAsync();

            return abuser;
        }

        private bool AbuserExists(int id)
        {
            return _context.Abuser.Any(e => e.Id == id);
        }
    }
}
