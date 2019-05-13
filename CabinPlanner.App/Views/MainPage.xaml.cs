﻿using System;

using CabinPlanner.App.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.Web.Http;
using Newtonsoft.Json;
using CabinPlanner.Model;
using Windows.UI.Xaml;

namespace CabinPlanner.App.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();
        HttpClient _httpClient = new HttpClient();


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
            /*
            var result = await _httpClient.GetAsync(Global.PeopleBaseUri);
            var json = await result.Content.ReadAsStringAsync();
            var people = JsonConvert.DeserializeObject<Person[]>(json);
            */


        }


        private async void Add_Click(object sender, RoutedEventArgs e)
        {
           // var person = new Person { FirstName = NewPersonName.Text.Split(' ')[0], LastName = NewPersonName.Text.Split(' ')[1] };
           // var json = JsonConvert.SerializeObject(person);
           //
           // var result = await _httpClient.PostAsync(PeopleBaseUri, new HttpStringContent(json, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json"));
           //
           // // read back from db
           // result = await _httpClient.GetAsync(PeopleBaseUri);
           // json = await result.Content.ReadAsStringAsync();
           // var people = JsonConvert.DeserializeObject<Person[]>(json);


        }

    }
}