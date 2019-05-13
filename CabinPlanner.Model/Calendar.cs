using System;
using System.Collections.Generic;
using System.Text;

namespace CabinPlanner.Model

{
    public class Calendar
    {
        public int CalendarId { get; set; }

        public List<PlannedTrip> PlannedTrips { get; set; } = new List<PlannedTrip>();


        public void AddTrips(List<PlannedTrip> trips)
        {
            foreach (PlannedTrip trip in trips)
            {
                PlannedTrips.Add(trip);
            }
        }
    }
}
