using System;
using System.Collections.ObjectModel;
using CabinPlanner.App.DataAccess;
using CabinPlanner.App.ViewModels;
using CabinPlanner.Model;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Web.Http;

namespace CabinPlanner.App.Views
{
    public sealed partial class NewCabinPage : Page
    {
        public NewCabinViewModel ViewModel { get; } = new NewCabinViewModel();

        private People peopleDataAccess = new People();
        private Cabins cabinsDataAccess = new Cabins();

        ObservableCollection<Person> peopleWithoutAccess;
        ObservableCollection<Person> peopleWaccess;

        HttpClient _httpClient = new HttpClient();

        public NewCabinPage()
        {
            InitializeComponent();
        }



        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {

            CabinOwnerField.Text = Global.User.ToString();

            peopleWithoutAccess = new ObservableCollection<Person>(await peopleDataAccess.GetPeopleAsync());
            peopleWaccess = new ObservableCollection<Person>();

            peopleWithoutAccess.Remove(Global.User);
            PeopleWithoutAccess.ItemsSource = peopleWithoutAccess;
            PeopleWithAccess.ItemsSource = peopleWaccess;
        }


        private async void AddCabinBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Cabin cabin = new Cabin { CabinName = cabinNameField.Text, Calendar = new Calendar() };

                await cabinsDataAccess.AddCabinAsync(cabin);
                await cabinsDataAccess.PutCabinOwnerAsync(cabin, Global.User);

                await cabinsDataAccess.PutCabinPersonAsync(cabin, Global.User);
                foreach (Person p in peopleWaccess)
                {
                    if(!p.Equals(Global.User))
                        await cabinsDataAccess.PutCabinPersonAsync(cabin, p);
                }

                Global.CurrentCabin = cabin;

                this.Frame.Navigate(typeof(TempCabinPage));

            }
            catch (Exception)
            {

                throw;
            }


        }


        private void MoveToAccessBtn_Click(object sender, RoutedEventArgs e)
        {
            var items = PeopleWithoutAccess.SelectedItems;

            foreach (Person person in items)
            {
                peopleWaccess.Add(person);
                peopleWithoutAccess.Remove(person);
            }
            PeopleWithoutAccess.ItemsSource = peopleWithoutAccess;
            PeopleWithAccess.ItemsSource = peopleWaccess;
        }


        private static void MoveSelectedItems(ListView source, ListView target)
        {
            while (source.SelectedItems.Count > 0)
            {
                ListViewItem temp = (ListViewItem)source.SelectedItems[0];
                source.Items.Remove(temp);
                target.Items.Add(temp);
            }
        }

        private void MoveFromAccessBtn_Click(object sender, RoutedEventArgs e)
        {
            var items = PeopleWithAccess.SelectedItems;

            foreach (Person person in items)
            {
                peopleWithoutAccess.Add(person);
                peopleWaccess.Remove(person);
            }
            PeopleWithoutAccess.ItemsSource = peopleWithoutAccess;
            PeopleWithAccess.ItemsSource = peopleWaccess;
        }
    }
}
