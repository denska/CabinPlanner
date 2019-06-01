using System;
using CabinPlanner.App.DataAccess;
using CabinPlanner.App.ViewModels;
using CabinPlanner.Model;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Web.Http;

namespace CabinPlanner.App.Views
{
    public sealed partial class LoginPage : Page
    {
        public LoginViewModel ViewModel { get; } = new LoginViewModel();

        HttpClient _httpClient = new HttpClient();

        private People peopleDataAccess = new People();


        public LoginPage()
        {
            InitializeComponent();
            

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
          
            
            foreach (Person p in await peopleDataAccess.GetPeopleAsync())
            {
                if (p.Email == emailField.Text && p.Password == passwordField.Password)
                {
                    Global.User = await peopleDataAccess.GetPersonAsync(p);
                    this.Frame.Navigate(typeof(MainPage));
                    break;
                }
            }

            errorTxt.Text = "*Login error";

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
