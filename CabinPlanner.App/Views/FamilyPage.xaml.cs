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
    public sealed partial class FamilyPage : Page
    {
        public FamilyViewModel ViewModel { get; } = new FamilyViewModel();

        static Uri PeopleBaseUri = new Uri("http://localhost:52981/api/people");
        static Uri FamiliesBaseUri = new Uri("http://localhost:52981/api/familes");

        HttpClient _httpClient = new HttpClient();


        public FamilyPage()
        {
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var result = await _httpClient.GetAsync(FamiliesBaseUri);
            var json = await result.Content.ReadAsStringAsync();
            var families = JsonConvert.DeserializeObject<Family[]>(json);

            Families.ItemsSource = families;
        }


        private async void Add_Click(object sender, RoutedEventArgs e)
        {
           var familie = (Family)Families.SelectedItem;

            Global.User.Family = familie;
           
           var json = JsonConvert.SerializeObject(Global.User);
           
           var result = await _httpClient.PostAsync(PeopleBaseUri, new HttpStringContent(json, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json"));
           
           // read back from db

           result = await _httpClient.GetAsync(FamiliesBaseUri);
           json = await result.Content.ReadAsStringAsync();

           var families = JsonConvert.DeserializeObject<Family[]>(json);          
           Families.ItemsSource = families;
        }
    }
}
