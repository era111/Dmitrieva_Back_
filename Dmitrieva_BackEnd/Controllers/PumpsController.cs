using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dmitrieva_BackEnd.Models;
using Microsoft.AspNetCore.Authorization;

namespace Dmitrieva_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PumpsController : ControllerBase
    {
        private readonly PumpContext _context;

        public PumpsController(PumpContext context)
        {
            _context = context;
        }

        // GET: api/Pumps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pump>>> GetPumps()
        {
            return await _context.Pumps.ToListAsync();
        }

        // GET: api/Pumps/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Pump>> GetPump(int id)
        {
            var pump = await _context.Pumps.FindAsync(id);

            if (pump == null)
            {
                return NotFound();
            }

            return pump;
        }

        [HttpGet("{id}/where")]

        public IEnumerable<Pump> getQuality()
        {
            return _context.getQuality();
        }

        // PUT: api/Pumps/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPump(int id, Pump pump)
        {
            if (id != pump.id)
            {
                return BadRequest();
            }

            _context.Entry(pump).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PumpExists(id))
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

        // POST: api/Pumps
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Pump>> PostPump(Pump pump)
        {
            _context.Pumps.Add(pump);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPump", new { id = pump.id }, pump);
        }

        // DELETE: api/Pumps/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<Pump>> DeletePump(int id)
        {
            var pump = await _context.Pumps.FindAsync(id);
            if (pump == null)
            {
                return NotFound();
            }

            _context.Pumps.Remove(pump);
            await _context.SaveChangesAsync();

            return pump;
        }

        private bool PumpExists(int id)
        {
            return _context.Pumps.Any(e => e.id == id);
        }
    }
}
