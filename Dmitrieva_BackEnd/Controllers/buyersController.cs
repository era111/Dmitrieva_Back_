using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dmitrieva_BackEnd.Models;

namespace Dmitrieva_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class buyersController : ControllerBase
    {
        private readonly buyerContext _context;

        public buyersController(buyerContext context)
        {
            _context = context;
        }

        [HttpGet("{id}/getRuss")]
        public IEnumerable<buyer> getSolvency()
        {
            return _context.getSolvency();
        }

        [HttpGet("{id}/countPumps")]

        public async Task<ActionResult<int>> getNumberPumps(int id)
        {
            var Buy = await _context.buyers.FindAsync(id);


            if (Buy == null)
            {
                return NotFound();
            }
            return Buy.getNumberPumps();
        }

        // GET: api/buyers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<buyer>>> Getbuyers()
        {
            return await _context.buyers.ToListAsync();
        }

        // GET: api/buyers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<buyer>> Getbuyer(int id)
        {
            var buyer = await _context.buyers.FindAsync(id);

            if (buyer == null)
            {
                return NotFound();
            }

            return buyer;
        }

        // PUT: api/buyers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putbuyer(int id, buyer buyer)
        {
            if (id != buyer.Id)
            {
                return BadRequest();
            }

            _context.Entry(buyer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!buyerExists(id))
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

        // POST: api/buyers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<buyer>> Postbuyer(buyer buyer)
        {
            _context.buyers.Add(buyer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getbuyer", new { id = buyer.Id }, buyer);
        }

        // DELETE: api/buyers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<buyer>> Deletebuyer(int id)
        {
            var buyer = await _context.buyers.FindAsync(id);
            if (buyer == null)
            {
                return NotFound();
            }

            _context.buyers.Remove(buyer);
            await _context.SaveChangesAsync();

            return buyer;
        }

        private bool buyerExists(int id)
        {
            return _context.buyers.Any(e => e.Id == id);
        }
    }
}
