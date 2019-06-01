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
        private Calendars calendarsDataAccess = new Calendars();

        DateTime fromDate;
        DateTime toDate;


        HttpClient _httpClient = new HttpClient();

        public TempCabinPage()
        {
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (Global.User == null)
            {
                this.Frame.Navigate(typeof(LoginPage));
                return;
            }

            ICollection<Cabin> cabins = new List<Cabin>(await peopleDataAccess.GetPersonCabinsAsync(Global.User));
            addTripBtn.IsEnabled = false;
            Cabins.ItemsSource = cabins;


            if (Global.CurrentCabin != null)
                if (Global.CurrentCabin.Calendar.PlannedTrips.Count != 0)
                    CommingTrips.ItemsSource = await calendarsDataAccess.GetCalendarTripsAsync(Global.CurrentCabin.Calendar);
        }

        private void AddCabinBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(NewCabinPage));
        }

        private async void Cabins_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Global.CurrentCabin = (Cabin)Cabins.SelectedItem;



            if (Global.CurrentCabin.Calendar != null)
            {
                CommingTrips.ItemsSource = await calendarsDataAccess.GetCalendarTripsAsync(Global.CurrentCabin.Calendar);
            }

           

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

        private async void AddTripBtn_Click(object sender, RoutedEventArgs e)
        {
            addTripBtn.IsEnabled = true;

            PlannedTrip trip = new PlannedTrip()
            {
                PlannedTripId = 0,
                //PersonId = Global.User.PersonId,
                Comment = descriptionField.Text,
                FromDate = fromDate,
                ToDate = toDate
            };

            if (Global.CurrentCabin.Calendar != null)
            {
                await calendarsDataAccess.PutCalendarTripAsync(Global.CurrentCabin.Calendar, trip);
                await calendarsDataAccess.PutCalendarTripAsync(Global.User.Calendar, trip);

                CommingTrips.ItemsSource = await calendarsDataAccess.GetCalendarTripsAsync(Global.CurrentCabin.Calendar);
            }
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
