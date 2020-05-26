using SQLiteApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Laba4_DB.Models
{
    public class CarViewModel
    {
        public static List<Car> InitDB()
        {
            var cars = new List<Car>()
            {
                new Car(){Id = 1, Brand = "Toyota", Color = "Black", Price = 15000, Type = "Hatchbacks ", Volume=3.2},
                new Car(){Id = 2, Brand = "Nissan", Color = "White", Price = 13000, Type = "Sedan ", Volume=2.1},
                new Car(){Id = 3, Brand = "Audi", Color = "Gray", Price = 20000, Type = "MPV ", Volume=4.5},
                new Car(){Id = 4, Brand = "Mersedes", Color = "Pink", Price = 25000, Type = "Coupe ", Volume=4.8},
                new Car(){Id = 5, Brand = "Porshe", Color = "Gold", Price = 30000, Type = "Convertibles ", Volume=5.0}
            };
            return cars;
        }
    }
}
