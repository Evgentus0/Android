using Laba4_DB.Helpers;
using Laba4_DB.Interfaces;
using Laba4_DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Laba4_DB.Views.DataBase
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataBaseMain : ContentPage
    {

        private readonly ICarRepository carRepository;
        public DataBaseMain(ICarRepository carRepository)
        {
            InitializeComponent();

            this.carRepository = carRepository;

            //carRepository.CreateRangeAsync(CarViewModel.InitDB());
            var cars = carRepository.GetAllAsync().Result;
            Init(cars.ToList());
        }

        private void Init(List<Car> cars)
        {
            //ScrollView scrollView = new ScrollView();
            //StackLayout stackLayout = new StackLayout();
            var filterTableSection = GetFilterTableSection();
            var viewTableSection = GetViewTableSection(cars.ToList());

            var table = new TableView()
            {
                Root = new TableRoot()
                {
                    filterTableSection,
                    viewTableSection
                }
            };

            table.Margin = new Thickness(4, 2, 4, 2);


            Content = table;
        }

        private TableSection GetFilterTableSection()
        {
            var tableSection = new TableSection("Filter");
            var car = new Car();

            tableSection.Add(new EntryCell() { Label = nameof(car.Id) });
            tableSection.Add(new EntryCell() { Label = nameof(car.Brand) });
            tableSection.Add(new EntryCell() { Label = nameof(car.Color) });
            tableSection.Add(new EntryCell() { Label = nameof(car.Type) });
            tableSection.Add(new EntryCell() { Label = nameof(car.Volume) });
            tableSection.Add(new EntryCell() { Label = nameof(car.Price) });

            var filter = new Button() { Text = "Filter" };
            filter.Clicked += FilterButton_clicked;

            //  var addItem = new Button() { Text = "Add Item" };
            //  addItem.Clicked += AddItemBuuton_clicked;

            tableSection.Add(new ViewCell() { View = filter });
            //  tableSection.Add(new ViewCell() { View = addItem });

            return tableSection;
        }

        private TableSection GetViewTableSection(List<Car> cars)
        {
            //var cars = await carRepository.GetAllAsync();

            var tableSection = new TableSection("Cars");

            var addItem = new Button() { Text = "Add Item" };
            addItem.Clicked += AddItemBuuton_clicked;

            var findAverageVolume = new Button() { Text = "Find Average Volume" };
            findAverageVolume.Clicked += FindAverageVolumeBuuton_clicked;

            tableSection.Add(new ViewCell() { View = addItem });
            tableSection.Add(new ViewCell() { View = findAverageVolume });

            foreach (var car in cars)
            {
                var grid = GetGrid();
                grid.Children.Add(new Label() { Text = car.Id.ToString() }, 0, 0);
                grid.Children.Add(new Label() { Text = car.Brand }, 1, 0);
                grid.Children.Add(new Label() { Text = car.Type }, 2, 0);
                grid.Children.Add(new Label() { Text = car.Color }, 3, 0);
                grid.Children.Add(new Label() { Text = car.Volume.ToString() }, 4, 0);
                grid.Children.Add(new Label() { Text = car.Price.ToString() }, 5, 0);

                var editButton = new Button() { Text = "Edit" };
                editButton.Clicked += EditButton_clicked;
                var deleteButton = new Button() { Text = "Delete" };
                deleteButton.Clicked += DeleteButton_clicked;

                grid.Children.Add(editButton, 6, 0);
                grid.Children.Add(deleteButton, 7, 0);

                var viewCell = new ViewCell() { View = grid };

                tableSection.Add(viewCell);
            }

            return tableSection;
        }

        private Grid GetGrid()
        {
            var grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Star });

            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0.05, GridUnitType.Star) });//{Width = GridLength.Auto});
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0.20, GridUnitType.Star) });//{Width = GridLength.Auto});
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0.20, GridUnitType.Star) });//{Width = GridLength.Auto});
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0.13, GridUnitType.Star) });//{Width = GridLength.Auto});
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0.08, GridUnitType.Star) });//{Width = GridLength.Auto});
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0.15, GridUnitType.Star) });//{Width = GridLength.Auto});
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0.10, GridUnitType.Star) });//{Width = GridLength.Auto});
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0.10, GridUnitType.Star) });//{ Width = GridLength.Auto})
            return grid;
        }

        private async void EditButton_clicked(object sender, EventArgs args)
        {
            var button = (Button)sender;
            var grid = (Grid)button.Parent;
            var label = (Label)grid.Children[0];

            int id = int.Parse(label.Text);

            Car car = await carRepository.GetByIdAsync(id);
            var editPage = new EditCar(car);

            editPage.EditSucceded += SuccessfulEdit;

            await Navigation.PushAsync(editPage);

        }

        private void SuccessfulEdit(object sender, EventArgs e)
        {
            var args = (EventEditCarArgs)e;
            var car = args.Car;

            var table = (TableView)Content;
            var root = table.Root;
            var section = root[1];

            var cell = (ViewCell)section.Where(x => { var cl = (ViewCell)x; return cl.View is Grid; }).First(x =>
            {
                var cl = (ViewCell)x;
                var gr = (Grid)cl.View;

                var lb = (Label)gr.Children[0];

                return int.Parse(lb.Text) == car.Id;
            });

            Grid grid = (Grid)cell.View;

            bool isUpdated = carRepository.UpdateAsync(car).Result;

            var labels = grid.Children.Where(x => x is Label).Select(x => (Label)x).ToList();

            labels[0].Text = car.Id.ToString();
            labels[1].Text = car.Brand;
            labels[2].Text = car.Type;
            labels[3].Text = car.Color;
            labels[4].Text = car.Volume.ToString();
            labels[5].Text = car.Price.ToString();
        }

        private async void DeleteButton_clicked(object sender, EventArgs args)
        {
            var button = (Button)sender;
            var grid = (Grid)button.Parent;
            var label = (Label)grid.Children[0];

            int id = int.Parse(label.Text);

            bool isDeleted = await carRepository.DeleteAsync(id);
            if (isDeleted)
            {
                var cars = await carRepository.GetAllAsync();
                Init(cars.ToList());
            }
        }

        private async void FilterButton_clicked(object sender, EventArgs args)
        {
            var button = (Button)sender;
            var cell = (ViewCell)button.Parent;
            var tableView = (TableView)cell.Parent;

            var section = tableView.Root.First();

            var newCar = section.Where(x => x is EntryCell).Select(x => (EntryCell)x).ToList();

            var car = new Car()
            {
                Id = newCar[0].Text != null ? int.Parse(newCar[0].Text) : -1,
                Brand = newCar[1].Text != null ? newCar[1].Text : string.Empty,
                Color = newCar[2].Text != null ? newCar[2].Text : string.Empty,
                Type = newCar[3].Text != null ? newCar[3].Text : string.Empty,
                Volume = newCar[4].Text != null ? double.Parse(newCar[4].Text) : -1,
                Price = newCar[5].Text != null ? decimal.Parse(newCar[5].Text) : -1
            };

            var cars = await carRepository.GetAllAsync();

            if (car.Id != -1)
            {
                cars = cars.Where(x => x.Id == car.Id);
            }
            if (!string.IsNullOrEmpty(car.Brand))
            {
                cars = cars.Where(x => x.Brand == car.Brand);
            }
            if (!string.IsNullOrEmpty(car.Color))
            {
                cars = cars.Where(x => x.Color == car.Color);
            }
            if (!string.IsNullOrEmpty(car.Type))
            {
                cars = cars.Where(x => x.Type == car.Type);
            }
            if (car.Volume != -1)
            {
                cars = cars.Where(x => x.Volume == car.Volume);
            }
            if (car.Price != -1)
            {
                cars = cars.Where(x => x.Price == car.Price);
            }

            Init(cars.ToList());
        }

        private async void AddItemBuuton_clicked(object sender, EventArgs args)
        {
            var addPage = new AddItem();

            addPage.AddSucceded += SuccessfulAdd;

            await Navigation.PushAsync(addPage);
        }

        private async void SuccessfulAdd(object sender, EventArgs e)
        {
            var args = (EventEditCarArgs)e;
            var car = args.Car;

            await carRepository.CreateAsync(car);

            var cars = await carRepository.GetAllAsync();
            Init(cars.ToList());
        }

        private async void FindAverageVolumeBuuton_clicked(object sender, EventArgs args)
        {
            var cars = await carRepository.GetAllAsync();
            var average = cars.Average(x => x.Volume);

            await DisplayAlert("Average Value", average.ToString(), "OK");

        }

    }
}