using CabinPlanner.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CabinPlanner.App.Core.Services
{
    public class CabinsDataService
    {


        private static IEnumerable<Cabin> AllOrders()
        {
            // The following is order summary data
            var data = new ObservableCollection<Cabin>
            {

            };
            return data;
        }

        private static IEnumerable<Cabin> _allOrders;

        // TODO WTS: Remove this once your ContentGrid page is displaying real data.
        public static ObservableCollection<Cabin> GetContentGridData(Person user)
        {
            _allOrders = user.Cabins;

            if (_allOrders == null)
            {
                _allOrders = new List<Cabin>();
            }

            return new ObservableCollection<Cabin>(_allOrders);
        }

    }
}
