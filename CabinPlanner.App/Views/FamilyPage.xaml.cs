using System;

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
        HttpClient _httpClient = new HttpClient();


        public FamilyPage()
        {
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var result = await _httpClient.GetAsync(PeopleBaseUri);
            var json = await result.Content.ReadAsStringAsync();
            var people = JsonConvert.DeserializeObject<Person[]>(json);

            People.ItemsSource = people;
        }


        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            var person = new Person { FirstName = NewPersonName.Text.Split(' ')[0], LastName = NewPersonName.Text.Split(' ')[1] };
            var json = JsonConvert.SerializeObject(person);

            var result = await _httpClient.PostAsync(PeopleBaseUri, new HttpStringContent(json, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json"));

            // read back from db
            result = await _httpClient.GetAsync(PeopleBaseUri);
            json = await result.Content.ReadAsStringAsync();
            var people = JsonConvert.DeserializeObject<Person[]>(json);

            People.ItemsSource = people;
        }
    }
}
