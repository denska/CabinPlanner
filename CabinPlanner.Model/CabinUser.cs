using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CabinPlanner.Model
{
    [Table("CabinUser")]
    public class CabinUser
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int CabinId { get; set; }
        public Cabin Cabin { get; set; }
    }
}