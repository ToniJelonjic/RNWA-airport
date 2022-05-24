using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REST_API;
using REST_API.Models;

namespace REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirplaneTypesController : ControllerBase
    {
        private readonly airportdbContext _context;

        public AirplaneTypesController(airportdbContext context)
        {
            _context = context;
        }

        // GET: api/AirplaneTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AirplaneType>>> GetAirplaneTypes()
        {
            return await _context.AirplaneTypes.ToListAsync();
        }

        // GET: api/AirplaneTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AirplaneType>> GetAirplaneType(int id)
        {
            var airplaneType = await _context.AirplaneTypes.FindAsync(id);

            if (airplaneType == null)
            {
                return NotFound();
            }

            return airplaneType;
        }

        // PUT: api/AirplaneTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAirplaneType(int id, AirplaneType airplaneType)
        {
            if (id != airplaneType.TypeId)
            {
                return BadRequest();
            }

            _context.Entry(airplaneType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AirplaneTypeExists(id))
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

        // POST: api/AirplaneTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AirplaneType>> PostAirplaneType(AirplaneType airplaneType)
        {
            _context.AirplaneTypes.Add(airplaneType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAirplaneType", new { id = airplaneType.TypeId }, airplaneType);
        }

        // DELETE: api/AirplaneTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAirplaneType(int id)
        {
            var airplaneType = await _context.AirplaneTypes.FindAsync(id);
            if (airplaneType == null)
            {
                return NotFound();
            }

            _context.AirplaneTypes.Remove(airplaneType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AirplaneTypeExists(int id)
        {
            return _context.AirplaneTypes.Any(e => e.TypeId == id);
        }
    }
}
