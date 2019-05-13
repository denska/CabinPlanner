using System;
using System.Linq;

using CabinPlanner.App.Core.Models;
using CabinPlanner.App.Core.Services;
using CabinPlanner.App.Helpers;
using CabinPlanner.Model;

namespace CabinPlanner.App.ViewModels
{
    public class CabinsDetailViewModel : Observable
    {
        private Cabin _item;

        public Cabin Item
        {
            get { return _item; }
            set { Set(ref _item, value); }
        }

        public CabinsDetailViewModel()
        {
        }

        public void Initialize(long orderId)
        {
            var data = CabinsDataService.GetContentGridData(Global.User);
            Item = data.First(i => i.CabinId == orderId);
        }
    }
}
