using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CabinPlanner.Model
{
    [Table("Family")]
    public class Family
    {

        public int FamilyId { get; set; }


        public string FamiliyName { get; set; }

        public ICollection<Person> FamilyMembers { get; } = new List<Person>();
        
    }
}
