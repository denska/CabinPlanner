using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CabinPlanner.Model
{
    [Table("PlannedTrip")]
    public class PlannedTrip
    {
        public int PlannedTripId { get; set; }

        public Person Planner { get; set; }

        public string Comment { get; set; }

        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }


        public ICollection<CalendarTrip> TripCalendars { get; } = new List<CalendarTrip>();
    }
}
