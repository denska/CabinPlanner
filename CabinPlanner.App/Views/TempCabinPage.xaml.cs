using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        DateTime fromDate;
        DateTime toDate;

        static Uri CabinsUsersUri = new Uri("http://localhost:52981/api/cabinusers");
        static Uri CabinsUri = new Uri("http://localhost:52981/api/cabins");

        HttpClient _httpClient = new HttpClient();

        public TempCabinPage()
        {
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var result = await _httpClient.GetAsync(CabinsUsersUri);
            var json = await result.Content.ReadAsStringAsync();
            var cabinUsers = JsonConvert.DeserializeObject<CabinUser[]>(json);

            var cresult = await _httpClient.GetAsync(CabinsUri);
            var cjson = await cresult.Content.ReadAsStringAsync();
            var cabins = JsonConvert.DeserializeObject<CabinUser[]>(cjson);

            var b = new HttpResponseMessage();

            foreach (CabinUser cu in cabinUsers)
            {
                if (cu.PersonId == Global.User.PersonId)
                    b = await _httpClient.GetAsync(new Uri(CabinsUri + "/" + cu.CabinId.ToString()));
                    Cabin c = (Cabin)b.Content;
                    Global.User.AccessToCabins.Add(cu);
            }

            //Cabins.ItemsSource = Global.User.CabinsAccess;
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
