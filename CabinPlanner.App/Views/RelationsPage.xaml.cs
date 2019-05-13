using System;

using CabinPlanner.App.ViewModels;

using Windows.UI.Xaml.Controls;

namespace CabinPlanner.App.Views
{
    public sealed partial class RelationsPage : Page
    {
        public RelationsViewModel ViewModel { get; } = new RelationsViewModel();

        public RelationsPage()
        {
            InitializeComponent();
        }
    }
}
