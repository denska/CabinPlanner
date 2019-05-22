using System;

using CabinPlanner.App.ViewModels;
using CabinPlanner.Model;
using Newtonsoft.Json;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Web.Http;

namespace CabinPlanner.App.Views
{
    public sealed partial class CabinsPage : Page
    {
        public CabinsViewModel ViewModel { get; } = new CabinsViewModel();

        HttpClient _httpClient = new HttpClient();

        public CabinsPage()
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

            //NameTxt.Text = Global.User.ToString();

            var result = await _httpClient.GetAsync(Global.PeopleBaseUri);
            var json = await result.Content.ReadAsStringAsync();
            var cabins = JsonConvert.DeserializeObject<CabinUser[]>(json);

            



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(NewCabinPage));
        }
    }
}
