using System;

using CabinPlanner.App.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.Web.Http;
using Windows.UI.Xaml;
using CabinPlanner.App.DataAccess;
using Windows.UI.Xaml.Input;

namespace CabinPlanner.App.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();
        HttpClient _httpClient = new HttpClient();


        private People peopleDataAccess = new People();
        private Calendars calendarsDataAccess = new Calendars();


        public MainPage()
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

            NameTxt.Text = Global.User.ToString();
            emailTxt.Text = Global.User.Email;


            if (Global.User.Calendar != null)
            {
                if (Global.User.AccessToCabins.Count != 0)
                    CommingTrips.ItemsSource = await calendarsDataAccess.GetCalendarTripsAsync(Global.User.Calendar);
            }

        }

        private  void Add_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await peopleDataAccess.DeletePersonAsync(Global.User);
            this.Frame.Navigate(typeof(LoginPage));
        }

        private async void Button1_Click(object sender, RoutedEventArgs e)
        {
            if (NameField.Visibility == Visibility.Visible)
            {
                Global.User.FirstName = NameField.Text.Split(" ")[0];
                Global.User.LastName = NameField.Text.Split(" ")[NameField.Text.Split(" ").Length - 1];

                NameField.Visibility = Visibility.Collapsed;
                NameTxt.Visibility = Visibility.Visible;

                NameTxt.Text = Global.User.ToString();

                await peopleDataAccess.PutPersonAsync(Global.User);
                return;
            }

            NameField.Visibility = Visibility.Visible;
            NameTxt.Visibility = Visibility.Collapsed;
        }

        private async void EnterKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                Global.User.FirstName = NameField.Text.Split(" ")[0];
                Global.User.LastName = NameField.Text.Split(" ")[NameField.Text.Split(" ").Length - 1];

                NameField.Visibility = Visibility.Collapsed;
                NameTxt.Visibility = Visibility.Visible;

                NameTxt.Text = Global.User.ToString();

                await peopleDataAccess.PutPersonAsync(Global.User);
            }
        }

        private void LogoutBtn_Click(object sender, RoutedEventArgs e)
        {
            Global.User = null;
            this.Frame.Navigate(typeof(LoginPage));
        }
    }
}
