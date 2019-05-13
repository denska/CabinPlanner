using System.Collections.Generic;

namespace CabinPlanner.Model
{
    public class CabinUsers
    {
        public int CabinUsersId { get; set; }
        public int CabinId { get; set; }
        public List<Person> CabinUsersList { get; set; }
    }
}