using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CabinPlanner.App.DataAccess;
using CabinPlanner.App.ViewModels;
using CabinPlanner.Model;
using Newtonsoft.Json;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Web.Http;

namespace CabinPlanner.App.Views
{
    public sealed partial class TempCabinPage : Page
    {

        public TempCabinViewModel ViewModel { get; } = new TempCabinViewModel();

        private People peopleDataAccess = new People();
        private Cabins cabinsDataAccess = new Cabins();

        DateTime fromDate;
        DateTime toDate;


        HttpClient _httpClient = new HttpClient();

        public TempCabinPage()
        {
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ICollection<Cabin> cabins = new List<Cabin>(await peopleDataAccess.GetPersonCabinsAsync(Global.User));
            addTripBtn.IsEnabled = false;
            Cabins.ItemsSource = cabins;
        }

        private void AddCabinBtn_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(NewCabinPage));
        }

        private void Cabins_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Global.CurrentCabin = (Cabin)Cabins.SelectedItem;



            if (Global.CurrentCabin.Calendar != null)
            {
                if (Global.CurrentCabin.Calendar.PlannedTrips != null)
                {
                    CommingTrips.ItemsSource = Global.CurrentCabin.Calendar.PlannedTrips;
                    return;
                }
            }

            CommingTrips.ItemsSource = null;

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

        private async void AddTripBtn_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            addTripBtn.IsEnabled = true;

            PlannedTrip trip = new PlannedTrip()
            {
                ToDate = toDate,
                FromDate = fromDate,
                Comment = descriptionField.Text
            };

            if (Global.CurrentCabin.Calendar == null)
            {
                Global.CurrentCabin.Calendar = new Calendar();
                Global.CurrentCabin.Calendar.PlannedTrips = new List<PlannedTrip>();
            }
            else if (Global.CurrentCabin.Calendar.PlannedTrips == null)
                Global.CurrentCabin.Calendar.PlannedTrips = new List<PlannedTrip>();



            if (Global.User.Calendar == null)
            {
                Global.User.Calendar = new Calendar();
                Global.User.Calendar.PlannedTrips = new List<PlannedTrip>();
            }
            else if (Global.User.Calendar.PlannedTrips == null)
                Global.User.Calendar.PlannedTrips = new List<PlannedTrip>();


            Global.User.Calendar.PlannedTrips.Add(trip);
            Global.CurrentCabin.Calendar.PlannedTrips.Add(trip);

            await cabinsDataAccess.PutCabinAsync(Global.CurrentCabin);
            await peopleDataAccess.PutPersonAsync(Global.User);

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
