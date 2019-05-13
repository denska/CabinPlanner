using System;
using System.Collections.Generic;
using System.Text;

namespace CabinPlanner.Model
{

    public class Cabin
    {
        public int CabinId { get; set; }

        public string CabinName { get; set; }

        public Person Owner { get; set; }

        public Calendar Calendar { get; set; }

        public List<Person> CabinCrew { get; set; } = new List<Person>();

    //public CabinUsers CabinUsers { get; set;}

}
}
