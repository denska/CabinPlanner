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
    public class CalendarsController : ControllerBase
    {
        private readonly CabinPlannerContext _context;

        public CalendarsController(CabinPlannerContext context)
        {
            _context = context;
        }

        // GET: api/Calendars
        [HttpGet]
        public IEnumerable<Calendar> GetCalendars()
        {
            return _context.Calendars;
        }

        // GET: api/Calendars/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCalendar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var calendar = await _context.Calendars.FindAsync(id);

            if (calendar == null)
            {
                return NotFound();
            }

            /*
            _context.Calendars
                .Where(s => s.CalendarId == id)
                    .Include(s => s.PlannedTrips)
                    .ThenInclude(pt => pt.PlannedTrip);
                    */
            return Ok(calendar);
        }

        [HttpGet("{id}/trips")]
        public async Task<IActionResult> GetCalendarTripsAsync([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CalendarTrips.Where(x => x.CalendarId == id);


            List<PlannedTrip> calendarTrips = new List<PlannedTrip>();

            foreach (CalendarTrip ct in _context.CalendarTrips.Where(x => x.CalendarId == id))
            {

                ct.PlannedTrip = _context.PlannedTrips.Find(ct.PlannedTripId);
                ct.PlannedTrip.TripCalendars.Clear();
                calendarTrips.Add(ct.PlannedTrip);
            }

            var calendar = await _context.Calendars.FindAsync(id);

            if (calendar.PlannedTrips == null)
            {
                return NotFound();
            }

            return Ok(calendarTrips);
        }

        // GET: api/students/5/courses/3
        [HttpGet("{id}/trips/{tripId}")]
        public async Task<IActionResult> GetCalendarsTrip([FromRoute] int id, [FromRoute] int tripId)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!CalendarTripExists(id, tripId))
            {
                return NotFound();
            }

            var trip = await _context.PlannedTrips.FindAsync(tripId);

            if (trip == null)
            {
                return NotFound();
            }

            return Ok(trip);
        }

        // PUT: api/Calendars/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalendar([FromRoute] int id, [FromBody] Calendar calendar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != calendar.CalendarId)
            {
                return BadRequest();
            }

            _context.Entry(calendar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalendarExists(id))
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
        [HttpPut("{id}/trips/{tripId}")]
        public async Task<IActionResult> AddTripToCalendar([FromRoute] int id, [FromRoute] int tripId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (CalendarTripExists(id, tripId))  // check if student already attends the course, if so return 204
            {
                return NoContent();
            }

            var calendarTrip = new CalendarTrip { CalendarId = id, PlannedTripId = tripId };
            _context.CalendarTrips.Add(calendarTrip);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCalendarsTrip", new { id, tripId }, calendarTrip);
        }

        [HttpPut("{id}/trips")]
        public async Task<IActionResult> AddTripToCalendar([FromRoute] int id, [FromBody] PlannedTrip plannedTrip)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (CalendarTripExists(id, plannedTrip.PlannedTripId))  // check if student already attends the course, if so return 204
            {
                return NoContent();
            }
            if (!TripExists(plannedTrip.PlannedTripId))
                _context.PlannedTrips.Add(plannedTrip);
            else
            {
                var ct = new CalendarTrip { CalendarId = id, PlannedTripId = plannedTrip.PlannedTripId };
                _context.CalendarTrips.Add(ct);
                return Ok(ct);
            }

            //await _context.SaveChangesAsync();

            var calendarTrip = new CalendarTrip { CalendarId = id, PlannedTripId = plannedTrip.PlannedTripId };
            _context.CalendarTrips.Add(calendarTrip);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCalendarsTrip", new { id, plannedTrip.PlannedTripId }, calendarTrip);
            //return Ok(calendarTrip);
        }

        private bool TripExists(int plannedTripId)
        {
            return _context.PlannedTrips.Any(p => p.PlannedTripId == plannedTripId);
        }

        // POST: api/Calendars
        [HttpPost]
        public async Task<IActionResult> PostCalendar([FromBody] Calendar calendar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Calendars.Add(calendar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCalendar", new { id = calendar.CalendarId }, calendar);
        }

        // DELETE: api/Calendars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalendar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var calendar = await _context.Calendars.FindAsync(id);
            if (calendar == null)
            {
                return NotFound();
            }

            _context.Calendars.Remove(calendar);
            await _context.SaveChangesAsync();

            return Ok(calendar);
        }

        private bool CalendarExists(int id)
        {
            return _context.Calendars.Any(e => e.CalendarId == id);
        }
        private bool CalendarTripExists(int id, int tripId)
        {
            return _context.CalendarTrips.Any(x => x.CalendarId == id && x.PlannedTripId == tripId);
        }
    }
}