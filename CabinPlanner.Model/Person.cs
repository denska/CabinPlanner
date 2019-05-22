using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CabinPlanner.Model
{
    [Table("Person")]
    public class Person
    {
        public int PersonId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public bool IsMan { get; set; }


        public DateTime DateOfBirth { get; set; }
        public Calendar Calendar { get; set; }
        public Family Family { get; set; }

        public ICollection<CabinUser> CabinsAccess { get; } = new List<CabinUser>();

        //public List<Relation> Relations { get; set; } = new List<Relation>();

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

    }
}
