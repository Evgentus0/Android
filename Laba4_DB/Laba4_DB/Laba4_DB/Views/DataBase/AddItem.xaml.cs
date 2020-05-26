using Laba4_DB.Helpers;
using Laba4_DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Laba4_DB.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddItem : ContentPage
    {
        private Car car;
        public event EventHandler AddSucceded;
        public AddItem()
        {
            InitializeComponent();
            Title = "Add Car";
            car = new Car();

            Init();
        }

        private void Init()
        {
            var tableSection = GetTableSection();

            addCar.Root = new TableRoot()
            {
                tableSection
            };
        }

        private TableSection GetTableSection()
        {
            var tableSection = new TableSection("Edit Car");

            tableSection.Add(new EntryCell() { Label = nameof(car.Brand)});
            tableSection.Add(new EntryCell() { Label = nameof(car.Color)});
            tableSection.Add(new EntryCell() { Label = nameof(car.Type), });
            tableSection.Add(new EntryCell() { Label = nameof(car.Volume)});
            tableSection.Add(new EntryCell() { Label = nameof(car.Price)});

            return tableSection;
        }

        private async void AddButton_clicked(object sender, EventArgs args)
        {
            var section = addCar.Root.First();

            var newCar = section.Select(x => (EntryCell)x).ToList();

            if (newCar.Any(x=>string.IsNullOrEmpty(x.Text)))
            {
                await DisplayAlert("Alarm", "Some values are null or empty!", "OK");
            }
            else if (!double.TryParse(newCar[3].Text, out double value1) || !double.TryParse(newCar[4].Text, out double value2))
            {
                await DisplayAlert("Alarm", "Volume or Price are incorrect!", "OK");
            }
            else
            {
                car.Brand = newCar[0].Text;
                car.Color = newCar[1].Text;
                car.Type = newCar[2].Text;
                car.Volume = double.Parse(newCar[3].Text);
                car.Price = decimal.Parse(newCar[4].Text);

                AddSucceded(this, new EventEditCarArgs() { Car = car });

                await Navigation.PopAsync();
            }
        }
    }
}