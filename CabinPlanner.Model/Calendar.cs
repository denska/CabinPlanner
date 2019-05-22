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

        public ICollection<PlannedTrip> PlannedTrips { get; set; } = new List<PlannedTrip>();


        public void AddTrips(List<PlannedTrip> trips)
        {
            foreach (PlannedTrip trip in trips)
            {
                PlannedTrips.Add(trip);
            }
        }
    }
}
