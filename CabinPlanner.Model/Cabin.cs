using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CabinPlanner.Model
{

    public class Cabin
    {
        public int CabinId { get; set; }

        public string CabinName { get; set; }

        public Person CabinOwner { get; set; }

        public Calendar Calendar { get; set; }

        public ICollection<CabinUser> CabinUsers { get; } = new List<CabinUser>();


    }
}
