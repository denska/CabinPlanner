using System;
using System.Collections.Generic;
using System.Text;

namespace CabinPlanner.Model
{
    public class CabinsUsers
    {
        public int CabinsUsersId { get; set; }
        public Cabin Cabin { get; set; }
        public Person person { get; set; }
    }
}
