using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CabinPlanner.DataAccess;
using CabinPlanner.Model;

namespace CabinPlanner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CabinsController : ControllerBase
    {
        private readonly CabinPlannerContext _context;

        public CabinsController(CabinPlannerContext context)
        {
            _context = context;
        }

        // GET: api/Cabins
        [HttpGet]
        public IEnumerable<Cabin> GetCabins()
        {
            return _context.Cabins;
        }

        // GET: api/Cabins/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCabin([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cabin = await _context.Cabins.FindAsync(id);

            if (cabin == null)
            {
                return NotFound();
            }

            return Ok(cabin);
        }

        // GET: api/people/*id*/cabins
        [HttpGet("{id}/people")]
        public async Task<IActionResult> GetCabinPeople([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cabinUsers = await _context.CabinsUsers.Where(x => x.CabinId == id).ToListAsync();
            if (cabinUsers == null)
            {
                return NotFound();
            }

            List<Person> cabinPeople = new List<Person>();
            foreach (CabinUser cabinUser in cabinUsers)
            {
                cabinPeople.Add(await _context.People.FindAsync(cabinUser.PersonId));
            }
            return Ok(cabinPeople);
        }

        // PUT: api/Cabins/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCabin([FromRoute] int id, [FromBody] Cabin cabin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cabin.CabinId)
            {
                return BadRequest();
            }

            _context.Entry(cabin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CabinExists(id))
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

        // POST: api/Cabins
        [HttpPost]
        public async Task<IActionResult> PostCabin([FromBody] Cabin cabin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Cabins.Add(cabin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCabin", new { id = cabin.CabinId }, cabin);
        }

        // DELETE: api/Cabins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCabin([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cabin = await _context.Cabins.FindAsync(id);
            if (cabin == null)
            {
                return NotFound();
            }

            _context.Cabins.Remove(cabin);
            await _context.SaveChangesAsync();

            return Ok(cabin);
        }

        private bool CabinExists(int id)
        {
            return _context.Cabins.Any(e => e.CabinId == id);
        }
    }
}