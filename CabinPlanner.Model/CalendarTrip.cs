using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CabinPlanner.Model
{
    [Table("CalendarTrip")]
    public class CalendarTrip
    {
        public int CalendarId { get; set; }
        public Calendar Calendar { get; set; }
        public int PlannedTripId { get; set; }
        public PlannedTrip PlannedTrip { get; set; }
    }
}
