using Laba4_DB.Views;
using SQLiteApp;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Laba4_DB
{
    public partial class App : Application
    {
        public App(ICarRepository carRepository)
        {
            InitializeComponent();

            MainPage = new MainPage(carRepository);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
