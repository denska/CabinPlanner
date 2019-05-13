using System;
using System.Collections.Generic;
using CabinPlanner.App.ViewModels;
using CabinPlanner.Model;
using Windows.UI.Xaml.Controls;

namespace CabinPlanner.App.Views
{
    public sealed partial class TempCabinPage : Page
    {
        public TempCabinViewModel ViewModel { get; } = new TempCabinViewModel();

        DateTime fromDate;
        DateTime toDate;


        public TempCabinPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Cabins.ItemsSource = Global.User.Cabins;
            addTripBtn.IsEnabled = false;
        }

        private void AddCabinBtn_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(NewCabinPage));
        }

        private void Cabins_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Global.CurrentCabin = (Cabin)Cabins.SelectedItem;

           // if (Global.CurrentCabin.Calendar.PlannedTrips != null)
           //     CommingTrips.ItemsSource = Global.CurrentCabin.Calendar.PlannedTrips;

        }

        private void CalendarView_SelectedDatesChanged(CalendarView sender, CalendarViewSelectedDatesChangedEventArgs args)
        {

            if (tripCalendar.SelectedDates.Count > 2)
                tripCalendar.SelectedDates.Clear();

            else if (tripCalendar.SelectedDates.Count == 2)
            {
                toFromTxt.Text = "From: " + tripCalendar.SelectedDates[0].ToString("dd.mm.yy") + " To: " + tripCalendar.SelectedDates[1].ToString("dd.mm.yy");
                fromDate = tripCalendar.SelectedDates[0].DateTime;
                toDate = tripCalendar.SelectedDates[1].DateTime;
                CheckTripBtn();
            }
        }

        private void AddTripBtn_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            addTripBtn.IsEnabled = true;

            PlannedTrip trip = new PlannedTrip()
            {
                ToDate = toDate,
                FromDate = fromDate,
                Comment = descriptionField.Text
            };

            if (Global.CurrentCabin.Calendar.PlannedTrips == null)
                Global.CurrentCabin.Calendar.PlannedTrips = new List<PlannedTrip>();

            Global.CurrentCabin.Calendar.PlannedTrips.Add(trip);
            if (Global.User.Calendar == null)
            {
                Global.User.Calendar = new Calendar();
                Global.User.Calendar.PlannedTrips = new List<PlannedTrip>();
            }
            else
            {
                Global.User.Calendar.PlannedTrips.Add(trip);
            }

            CommingTrips.ItemsSource = Global.CurrentCabin.Calendar.PlannedTrips;

        }


        void CheckTripBtn()
        {
            if (Global.CurrentCabin != null && toDate != null && fromDate != null)
            {
                addTripBtn.IsEnabled = true;
            }
            else
            {
                addTripBtn.IsEnabled = false;
            }
        }
    }
}
