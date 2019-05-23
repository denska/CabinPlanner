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
    public class CabinUsersController : ControllerBase
    {
        private readonly CabinPlannerContext _context;

        public CabinUsersController(CabinPlannerContext context)
        {
            _context = context;
        }

        // GET: api/CabinUsers
        [HttpGet]
        public IEnumerable<CabinUser> GetCabinsUsers()
        {
            return _context.CabinsUsers;
        }

        // GET: api/CabinUsers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCabinUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cabinUser = await _context.CabinsUsers.FindAsync(id);

            if (cabinUser == null)
            {
                return NotFound();
            }

            return Ok(cabinUser);
        }

        // PUT: api/CabinUsers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCabinUser([FromRoute] int id, [FromBody] CabinUser cabinUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cabinUser.PersonId)
            {
                return BadRequest();
            }

            _context.Entry(cabinUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CabinUserExists(id))
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

        // POST: api/CabinUsers
        [HttpPost]
        public async Task<IActionResult> PostCabinUser([FromBody] CabinUser cabinUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CabinsUsers.Add(cabinUser);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CabinUserExists(cabinUser.PersonId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCabinUser", new { id = cabinUser.PersonId }, cabinUser);
        }

        // DELETE: api/CabinUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCabinUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cabinUser = await _context.CabinsUsers.FindAsync(id);
            if (cabinUser == null)
            {
                return NotFound();
            }

            _context.CabinsUsers.Remove(cabinUser);
            await _context.SaveChangesAsync();

            return Ok(cabinUser);
        }

        private bool CabinUserExists(int id)
        {
            return _context.CabinsUsers.Any(e => e.PersonId == id);
        }
    }
}