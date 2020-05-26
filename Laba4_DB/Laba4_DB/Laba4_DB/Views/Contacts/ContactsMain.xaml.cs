using Lab5_Contacts.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Laba4_DB.Views.Contacts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactsMain : ContentPage
    {
        public ContactsMain()
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