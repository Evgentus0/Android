using Lab6_Maps.Views;
using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Lab6_Maps
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();


            Init();
        }

        private void Init()
        {
            var grid = GetGrid();

            Content = grid;
        }

        private Grid GetGrid()
        {
            var grid = new Grid();

            grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });

            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Star });

            var currentLocationButton = new Button() { Text = "Current Location" };
            currentLocationButton.Clicked += GetCurrentLocationButton_click;

            var findLocation = new Button() { Text = "Find Location" };
            findLocation.Clicked += FindLocationButton_click;

            grid.Children.Add(currentLocationButton, 0, 0);
            grid.Children.Add(findLocation, 0, 1);

            return grid;
        }

        private async void GetCurrentLocationButton_click(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new CurrentLocation());
        }

        private async void FindLocationButton_click(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new FindLocation());
        }

    }
}
