﻿using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

using CabinPlanner.App.Core.Models;
using CabinPlanner.App.Core.Services;
using CabinPlanner.App.Helpers;
using CabinPlanner.App.Services;
using CabinPlanner.App.Views;
using CabinPlanner.Model;
using Microsoft.Toolkit.Uwp.UI.Animations;

namespace CabinPlanner.App.ViewModels
{
    public class CabinsViewModel : Observable
    {
        private ICommand _itemClickCommand;

        public ICommand ItemClickCommand => _itemClickCommand ?? (_itemClickCommand = new RelayCommand<Cabin>(OnItemClick));

        public ObservableCollection<Cabin> Source
        {
            get
            {
                // TODO WTS: Replace this with your actual data
                return CabinsDataService.GetContentGridData(Global.User);
            }
        }

        public CabinsViewModel()
        {
        }

        private void OnItemClick(Cabin clickedItem)
        {
            if (clickedItem != null)
            {
                NavigationService.Frame.SetListDataItemForNextConnectedAnimation(clickedItem);
                NavigationService.Navigate<CabinsDetailPage>(clickedItem.CabinId);
            }
        }
    }
}
