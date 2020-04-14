using Laba4_DB.Helpers;
using Laba4_DB.Interfaces;
using Laba4_DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Laba4_DB.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditCar : ContentPage
    {
        private Car car;

        public event EventHandler EditSucceded;

        public EditCar(Car car)
        {
            InitializeComponent();
            Title = "Edit Car";
            this.car = car;
            Init();
        }

        private void Init()
        {
            var tableSection = GetTableSection();

            editCar.Root = new TableRoot()
            {
                tableSection
            };
        }

        private TableSection GetTableSection()
        {
            var tableSection = new TableSection("Edit Car");

            tableSection.Add(new EntryCell() { Label = nameof(car.Id), Text = car.Id.ToString(), IsEnabled=false });
            tableSection.Add(new EntryCell() { Label = nameof(car.Brand),  Text= car.Brand });
            tableSection.Add(new EntryCell() { Label = nameof(car.Color),  Text= car.Color });
            tableSection.Add(new EntryCell() { Label = nameof(car.Type),   Text= car.Type });
            tableSection.Add(new EntryCell() { Label = nameof(car.Volume), Text= car.Volume.ToString() });
            tableSection.Add(new EntryCell() { Label = nameof(car.Price),  Text= car.Price.ToString() });

            return tableSection;
        }

       private async void SaveButton_clicked(object sender, EventArgs args)
        {
            var section = editCar.Root.First();

            var newCar = section.Select(x=>(EntryCell)x).ToList();

            car.Brand = newCar[1].Text;
            car.Color = newCar[2].Text;
            car.Type = newCar[3].Text;
            car.Volume = double.Parse(newCar[4].Text);
            car.Price = decimal.Parse(newCar[5].Text);

            EditSucceded(this, new EventEditCarArgs() { Car = car});

            await Navigation.PopAsync();
        }
    }
}