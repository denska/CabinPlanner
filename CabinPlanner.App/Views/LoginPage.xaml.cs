using System;
using System.Collections.Generic;
using CabinPlanner.App.DataAccess;
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

        private People peopleDataAccess = new People();


        public LoginPage()
        {
            InitializeComponent();
            

        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
            
        }



        private async void Button_Click(object sender, RoutedEventArgs e)
        {
          
            
            foreach (Person p in await peopleDataAccess.GetPeopleAsync())
            {
                if (p.Email == emailField.Text && p.Password == passwordField.Password)
                {
                    Global.User = p;
                    //emailField.Text = ("Worked! User: " + Global.User.ToString());
                    this.Frame.Navigate(typeof(MainPage));
                    break;
                }
            }

            //Loggin failed    

        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(RegisterPage));
        }

        private void EnterKeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                Button_Click(sender, e);
            }
        }
    }
}
