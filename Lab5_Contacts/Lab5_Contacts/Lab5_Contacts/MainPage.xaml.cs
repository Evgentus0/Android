using Lab5_Contacts.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Lab5_Contacts
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void CheckAllContacts_click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AllContacts());
        }

        private async void CheckFilteredContacts_click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AllContacts(x => !string.IsNullOrWhiteSpace(x.Number) && x.Number.Contains("050")));
        }
    }
}
