using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventoryAPI;
using InventoryAPI.Models;

namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivestocksController : ControllerBase
    {
        private readonly InventoryDBContext _context;

        public LivestocksController(InventoryDBContext context)
        {
            _context = context;
        }

        // GET: api/Livestocks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livestock>>> GetLivestock()
        {
          if (_context.Livestock == null)
          {
              return NotFound();
          }
            return await _context.Livestock.ToListAsync();
        }

        // GET: api/Livestocks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Livestock>> GetLivestock(Guid id)
        {
          if (_context.Livestock == null)
          {
              return NotFound();
          }
            var livestock = await _context.Livestock.FindAsync(id);

            if (livestock == null)
            {
                return NotFound();
            }

            return livestock;
        }

        // PUT: api/Livestocks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLivestock(Guid id, Livestock livestock)
        {
            if (id != livestock.Id)
            {
                return BadRequest();
            }

            _context.Entry(livestock).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LivestockExists(id))
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

        // POST: api/Livestocks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Livestock>> PostLivestock(Livestock livestock)
        {
          if (_context.Livestock == null)
          {
              return Problem("Entity set 'InventoryDBContext.Livestock'  is null.");
          }
            _context.Livestock.Add(livestock);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLivestock", new { id = livestock.Id }, livestock);
        }

        // DELETE: api/Livestocks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLivestock(Guid id)
        {
            if (_context.Livestock == null)
            {
                return NotFound();
            }
            var livestock = await _context.Livestock.FindAsync(id);
            if (livestock == null)
            {
                return NotFound();
            }

            _context.Livestock.Remove(livestock);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LivestockExists(Guid id)
        {
            return (_context.Livestock?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
