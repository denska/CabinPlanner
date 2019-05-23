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
    public class FamiliesController : ControllerBase
    {
        private readonly CabinPlannerContext _context;

        public FamiliesController(CabinPlannerContext context)
        {
            _context = context;
        }

        // GET: api/Families
        [HttpGet]
        public IEnumerable<Family> GetFamilies()
        {
            return _context.Families;
        }

        // GET: api/Families/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFamily([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var family = await _context.Families.FindAsync(id);

            if (family == null)
            {
                return NotFound();
            }

            return Ok(family);
        }

        // PUT: api/Families/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFamily([FromRoute] int id, [FromBody] Family family)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != family.FamilyId)
            {
                return BadRequest();
            }

            _context.Entry(family).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FamilyExists(id))
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

        // POST: api/Families
        [HttpPost]
        public async Task<IActionResult> PostFamily([FromBody] Family family)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Families.Add(family);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFamily", new { id = family.FamilyId }, family);
        }

        // DELETE: api/Families/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFamily([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var family = await _context.Families.FindAsync(id);
            if (family == null)
            {
                return NotFound();
            }

            _context.Families.Remove(family);
            await _context.SaveChangesAsync();

            return Ok(family);
        }

        private bool FamilyExists(int id)
        {
            return _context.Families.Any(e => e.FamilyId == id);
        }
    }
}