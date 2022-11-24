using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kemergency.Areas.FireTrackK.Models;
using Kemergency.Data;

namespace Kemergency.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class FireTrackBookingsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FireTrackBookingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/FireTrackBookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FireTrackBooking>>> GetFireTrackBookings()
        {
            return await _context.FireTrackBookings.ToListAsync();
        }

        // GET: api/FireTrackBookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FireTrackBooking>> GetFireTrackBooking(int id)
        {
            var fireTrackBooking = await _context.FireTrackBookings.FindAsync(id);

            if (fireTrackBooking == null)
            {
                return NotFound();
            }

            return fireTrackBooking;
        }

        // PUT: api/FireTrackBookings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFireTrackBooking(int id, FireTrackBooking fireTrackBooking)
        {
            if (id != fireTrackBooking.Id)
            {
                return BadRequest();
            }

            _context.Entry(fireTrackBooking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FireTrackBookingExists(id))
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

        // POST: api/FireTrackBookings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FireTrackBooking>> PostFireTrackBooking(FireTrackBooking fireTrackBooking)
        {
            _context.FireTrackBookings.Add(fireTrackBooking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFireTrackBooking", new { id = fireTrackBooking.Id }, fireTrackBooking);
        }

        // DELETE: api/FireTrackBookings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFireTrackBooking(int id)
        {
            var fireTrackBooking = await _context.FireTrackBookings.FindAsync(id);
            if (fireTrackBooking == null)
            {
                return NotFound();
            }

            _context.FireTrackBookings.Remove(fireTrackBooking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FireTrackBookingExists(int id)
        {
            return _context.FireTrackBookings.Any(e => e.Id == id);
        }
    }
}
