using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CabinPlanner.Model
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsMan { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        public DateTime DateOfBirth { get; set; }
        public Calendar Calendar { get; set; }
        public Family Family { get; set; }

        [NotMapped]
        public List<Cabin> Cabins { get; set; }

        //public List<Relation> Relations { get; set; } = new List<Relation>();

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

    }
}
