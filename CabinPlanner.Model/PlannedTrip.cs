using System;
using System.Collections.Generic;
using System.Text;

namespace CabinPlanner.Model
{
    public class PlannedTrip
    {
        public int PlannedTripId { get; set; }

        public Person Planner { get; set; }
        public string Comment { get; set; }

        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
