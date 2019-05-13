using System;
using System.Collections.Generic;
using System.Text;

namespace CabinPlanner.Model
{
    public class Relation
    {
        public int RelationId { get; set; }

        public string TheirRelation { get; set; }
        public Person PersonA { get; set; }
        public Person PersonB { get; set; }
    }
}
