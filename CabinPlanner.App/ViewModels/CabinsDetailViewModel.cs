using System;
using System.Collections.Generic;
using System.Linq;

using CabinPlanner.App.Core.Models;
using CabinPlanner.App.Core.Services;
using CabinPlanner.App.Helpers;
using CabinPlanner.Model;

namespace CabinPlanner.App.ViewModels
{
    public class CabinsDetailViewModel : Observable
    {
        private CabinUser _item;

        public CabinUser Item
        {
            get { return _item; }
            set { Set(ref _item, value); }
        }

        public CabinsDetailViewModel()
        {
        }

        public void Initialize(long orderId)
        {
            var data = (Global.User.CabinsAccess);
            Item = data.First(i => i.CabinId == orderId);
        }
    }
}
