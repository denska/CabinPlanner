using System;
using System.Collections.Generic;
using CabinPlanner.App.ViewModels;
using CabinPlanner.Model;
using Newtonsoft.Json;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Web.Http;

namespace CabinPlanner.App.Views
{
    public sealed partial class LoginPage : Page
    {
        public LoginViewModel ViewModel { get; } = new LoginViewModel();
        static Uri PeopleBaseUri = new Uri("http://localhost:52981/api/people");
        HttpClient _httpClient = new HttpClient();


        public LoginPage()
        {
            InitializeComponent();
            

        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            /*
            var result = await _httpClient.GetAsync(PeopleBaseUri);
            var json = await result.Content.ReadAsStringAsync();
            people = JsonConvert.DeserializeObject<Person[]>(json);
            */
        }


        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            /*
            var result = await _httpClient.GetAsync(PeopleBaseUri);
            var json = await result.Content.ReadAsStringAsync();
            people = JsonConvert.DeserializeObject<Person[]>(json);
            */
            
            foreach (Person p in MyTestData.GetInstance().People)
            {
                if (p.Email == emailField.Text && p.Password == passwordField.Password)
                {
                    Global.User = p;
                    //emailField.Text = ("Worked! User: " + Global.User.ToString());
                    this.Frame.Navigate(typeof(MainPage));
                    break;
                }
            }

            

        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(RegisterPage));
        }
    }
}
