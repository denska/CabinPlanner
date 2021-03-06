﻿using System;
using CabinPlanner.App.DataAccess;
using CabinPlanner.App.ViewModels;
using CabinPlanner.Model;
using Newtonsoft.Json;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Web.Http;

namespace CabinPlanner.App.Views
{
    public sealed partial class RegisterPage : Page
    {
        public RegisterViewModel ViewModel { get; } = new RegisterViewModel();


        People peopleDataAccess = new People();

        static Uri PeopleBaseUri = new Uri("http://localhost:52981/api/people");
        HttpClient _httpClient = new HttpClient();



        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
            var result = await _httpClient.GetAsync(PeopleBaseUri);
            var json = await result.Content.ReadAsStringAsync();
            var people = JsonConvert.DeserializeObject<Person[]>(json);
            

        }


        private async void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                var person = new Person { FirstName = firstNameField.Text, LastName = lastNameField.Text, Email = emailField.Text, Password = passwordField.Password, DateOfBirth = birthdayField.Date.UtcDateTime, IsMan = (bool)isMan.IsChecked };

                await peopleDataAccess.AddPersonAsync(person);

                Global.User = person;
                this.Frame.Navigate(typeof(MainPage));
            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}
