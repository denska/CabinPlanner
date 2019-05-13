using CabinPlanner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinPlanner.App.ViewModels
{
    static class Global
    {
        public static Person User { get; set; }
        public static Cabin CurrentCabin { get; set; }

        public static Uri PeopleBaseUri { get; set; } = new Uri("http://localhost:52981/api/people");
        public static Uri CabinsBaseUri { get; set; } = new Uri("http://localhost:52981/api/cabins");
    }
}
