using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CabinPlanner.Model

{
    [Table("Calendar")]
    public class Calendar
    {
        public int CalendarId { get; set; }
        [Required]



        public ICollection<CalendarTrip> PlannedTrips { get; } = new List<CalendarTrip>();

        //public ICollection<PlannedTrip> PlannedTrips { get; set; } = new List<PlannedTrip>();

    }
}
