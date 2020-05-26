using Plugin.ContactService.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab5_Contacts.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllContacts : ContentPage
    {
        public AllContacts(Func<Contact, bool> predicat)
        {
            InitializeComponent();

            Initialize(predicat);
        }

        public AllContacts()
        {
            InitializeComponent();

            Initialize();
        }

        private async void Initialize()
        {
            var contacts = await Plugin.ContactService.CrossContactService.Current.GetContactListAsync();

            var tableSection = GetTableSection(contacts);

            contactsTable.Root = new TableRoot()
            {
                tableSection
            };
        }

        private async void Initialize(Func<Contact, bool> predicat)
        {
            var contactsList = await Plugin.ContactService.CrossContactService.Current.GetContactListAsync();
            var contacts = contactsList.Where(predicat).ToList();

            var tableSection = GetTableSection(contacts);

            contactsTable.Root = new TableRoot()
            {
                tableSection
            };
        }

        private TableSection GetTableSection(IEnumerable<Contact> contacts)
        {
            var tableSection = new TableSection("Contacts");

            foreach(var c in contacts)
            {
                var grid = GetGrid();

                grid.Children.Add(new Label() { Text = c.Name }, 0, 0);
                grid.Children.Add(new Label() { Text = c.Number }, 1, 0);

                var viewCell = new ViewCell() { View = grid };

                tableSection.Add(viewCell);
            }

            return tableSection;
        }

        private Grid GetGrid()
        {
            var grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Star });

            grid.ColumnDefinitions.Add(new ColumnDefinition() {Width = GridLength.Auto}); //{ Width = new GridLength(0.05, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto }); //{ Width = new GridLength(0.20, GridUnitType.Star) });

            return grid;
        }
    }
}