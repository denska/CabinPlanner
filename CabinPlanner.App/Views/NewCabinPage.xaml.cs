using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CabinPlanner.App.ViewModels;
using CabinPlanner.Model;
using Newtonsoft.Json;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Web.Http;

namespace CabinPlanner.App.Views
{
    public sealed partial class NewCabinPage : Page
    {
        public NewCabinViewModel ViewModel { get; } = new NewCabinViewModel();


        ObservableCollection<Person> peopleWithoutAccess;
        ObservableCollection<Person> peopleWaccess;

        //ObservableCollection<Person> ObsPeople = peopleWaccess;



        HttpClient _httpClient = new HttpClient();

        public NewCabinPage()
        {
            InitializeComponent();
        }



        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            /*
            var result = await _httpClient.GetAsync(Global.CabinsBaseUri);
            var json = await result.Content.ReadAsStringAsync();
            var cabins = JsonConvert.DeserializeObject<Cabin[]>(json);
            */
            peopleWithoutAccess = new ObservableCollection<Person>(MyTestData.GetInstance().People);
            peopleWaccess = new ObservableCollection<Person>();
            PeopleWithoutAccess.ItemsSource = peopleWithoutAccess;
            //PeopleWithAccess.ItemsSource = peopleWaccess; 
        }


        private async void AddCabinBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var cabin = new Cabin { CabinName = cabinNameField.Text, CabinOwner = Global.User, Calendar = new Calendar() };

                MyTestData.GetInstance().Cabins.Add(cabin);

                if (Global.User.AccessToCabins == null)
                    

                Global.User.AccessToCabins.Add(new CabinUser() {CabinId = cabin.CabinId, Cabin = cabin, PersonId = Global.User.PersonId, Person = Global.User });

                foreach (Person p in peopleWaccess)
                {
                    
                    Global.User.AccessToCabins.Add(new CabinUser() { CabinId = cabin.CabinId, Cabin = cabin, PersonId = p.PersonId, Person = p });
                }

                //Global.User.Cabins.Add(cabin);
                /*
                var json = JsonConvert.SerializeObject(cabin);


                var result = await _httpClient.PostAsync(Global.CabinsBaseUri, new HttpStringContent(json, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json"));

                //var json1 = JsonConvert.SerializeObject(Global.User);
                //var result1 = await _httpClient.PostAsync(Global.CabinsBaseUri, new HttpStringContent(json1, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json"));
                */


                this.Frame.Navigate(typeof(TempCabinPage));

            }
            catch (Exception)
            {

                throw;
            }


        }


        private async void MoveToAccessBtn_Click(object sender, RoutedEventArgs e)
        {
            var items = PeopleWithoutAccess.SelectedItems;

            foreach (Person person in items)
            {
                peopleWaccess.Add(person);
                //People.Items.Add(person);
                peopleWithoutAccess.Remove(person);
                //PeopleWithAccess.Items.Remove(person);
            }
            PeopleWithoutAccess.ItemsSource = peopleWithoutAccess;
            PeopleWithAccess.ItemsSource = peopleWaccess;
            // Page_Loaded(sender, e);
        }


        private static void MoveSelectedItems(ListView source, ListView target)
        {
            while (source.SelectedItems.Count > 0)
            {
                ListViewItem temp = (ListViewItem) source.SelectedItems[0];
                source.Items.Remove(temp);
                target.Items.Add(temp);
            }
        }
    }
}
