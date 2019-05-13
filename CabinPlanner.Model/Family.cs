using System;
using System.Collections.Generic;
using System.Text;

namespace CabinPlanner.Model
{
    public class Family
    {

        public int FamilyId { get; set; }


        public string FamiliyName { get; set; }
        public List<Person> FamilyMembers { get; set; }
        

    }
}
