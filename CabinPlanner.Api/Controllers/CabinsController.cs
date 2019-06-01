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

            _context.Cabins
                .Where(s => s.CabinId == id)
                .Include(p => p.CabinOwner);

            return Ok(cabin);
        }

        // GET: api/students/5/courses/3
        [HttpGet("{id}/people/{personId}")]
        public async Task<IActionResult> GetCabinsPerson([FromRoute] int id, [FromRoute] int personId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!CabinPersonExists(id, personId))
            {
                return NotFound();
            }

            var person = await _context.People.FindAsync(personId);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        // GET: api/students/5/courses/3
        [HttpGet("{id}/owner/{personId}")]
        public async Task<IActionResult> GetCabinsOwner([FromRoute] int id, [FromRoute] int personId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!CabinOwnerExists(id, personId))
            {
                return NotFound();
            }

            var person = await _context.People.FindAsync(personId);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
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

        // PUT: api/students/5/courses/3
        [HttpPut("{id}/people/{personId}")]
        public async Task<IActionResult> AddPersonToCabin([FromRoute] int id, [FromRoute] int personId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (CabinPersonExists(id, personId))  // check if student already attends the course, if so return 204
            {
                return NoContent();
            }

            var cabinUser = new CabinUser { PersonId = personId, CabinId = id };
            _context.CabinUsers.Add(cabinUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCabinsPerson", new { personId, id }, cabinUser);
        }

        // PUT: api/students/5/courses/3
        [HttpPut("{id}/owner/{personId}")]
        public async Task<IActionResult> AddOwnerToCabin([FromRoute] int id, [FromRoute] int personId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (CabinOwnerExists(id, personId))  // check if student already attends the course, if so return 204
            {
                return NoContent();
            }

            _context.Cabins.Find(id).CabinOwner =  _context.People.Find(personId);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCabinsOwner", new { id, personId }, _context.People.Find(personId));
        }

        /*
        // PUT: api/students/5/courses/3
        [HttpPut("{id}/Calendar/{calendarId}")]
        public async Task<IActionResult> AddTripToCalendar([FromRoute] int id, [FromBody] PlannedTrip pt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!CabinExists(id))
            {
                return NoContent();
            }

            CalendarTrip calendarTrip = new CalendarTrip() { CalendarId = _context.Cabins.Find(id).Calendar.CalendarId, PlannedTripId = pt.PlannedTripId };

            _context.Cabins.Find(id).Calendar.PlannedTrips.Add(calendarTrip);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlannedTrip", new { id, pt.PlannedTripId }, _context.PlannedTrips.Find(pt.PlannedTripId));

        }
        */

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
        private bool CabinPersonExists(int cabinId, int personId)
        {
            return _context.CabinUsers.Any(sc => sc.CabinId == cabinId && sc.PersonId == personId);
        }
                private bool CabinOwnerExists(int id, int personId)
        {
            return _context.Cabins.Any(e => e.CabinId == id && e.CabinOwner.PersonId == personId); ;
        }
    }
}