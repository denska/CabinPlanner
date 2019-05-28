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
    public class PeopleController : ControllerBase
    {
        private readonly CabinPlannerContext _context;

        public PeopleController(CabinPlannerContext context)
        {
            _context = context;
        }

        // GET: api/People
        [HttpGet]
        public IEnumerable<Person> GetPeople()
        {
            return _context.People;
        }

        // GET: api/People/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerson([FromRoute] int id, [FromQuery] bool withCourses = true)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var person = await _context.People.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }
            
            if (withCourses)  // include course information
                _context.People
                    .Where(s => s.PersonId == id)
                    .Include(s => s.AccessToCabins)
                    .ThenInclude(cu => cu.Cabin)
                    .Load();
            

            return Ok(person);
        }

        // GET: api/people/*id*/cabins
        [HttpGet("{id}/cabins")]
        public async Task<IActionResult> GetPersonCabinAsync([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cabinUsers = await _context.CabinsUsers.Where(x => x.PersonId == id).ToListAsync();
            if (cabinUsers == null)
            {
                return NotFound();
            }

            List<Cabin> personCabins = new List<Cabin>();
            foreach (CabinUser cabinUser in cabinUsers)
            {
                personCabins.Add(await _context.Cabins.FindAsync(cabinUser.CabinId));
            }
            return Ok(personCabins);
        }

        // PUT: api/People/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson([FromRoute] int id, [FromBody] Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != person.PersonId)
            {
                return BadRequest();
            }

            _context.Entry(person).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
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

        // POST: api/People
        [HttpPost]
        public async Task<IActionResult> PostPerson([FromBody] Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.People.Add(person);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerson", new { id = person.PersonId }, person);
        }

        // DELETE: api/People/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var person = await _context.People.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            _context.People.Remove(person);
            await _context.SaveChangesAsync();

            return Ok(person);
        }

        private bool PersonExists(int id)
        {
            return _context.People.Any(e => e.PersonId == id);
        }
    }
}