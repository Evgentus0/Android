using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Laba4_DB.Views.Helpers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HelpPage : ContentPage
    {
        public HelpPage()
        {
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            var stack = new StackLayout();
            var scroll = new ScrollView();

            var titleStyle = new Style(typeof(Label))
            {
                Setters = 
                {
                    new Setter { Property = Label.TextColorProperty, Value = Color.Black },
                    new Setter { Property = Label.FontSizeProperty, Value = 22 },
                    new Setter {Property = Label.MarginProperty, Value = 15}
                }
            };

            var contentStyle = new Style(typeof(Label))
            {
                Setters =
                {
                    new Setter { Property = Label.TextColorProperty, Value = Color.Gray },
                    new Setter { Property = Label.FontSizeProperty, Value = 15 },
                    new Setter { Property = Label.MarginProperty, Value = 10}
                }
            };

            var lab123Title = new Label()
            {
                Text = "Lab 1, 2, 3",
                Style = titleStyle
            };
            var lab123Content = new Label()
            {
                Style = contentStyle,
                Text = "You can find this functionality in \"Lab 1, 2, 3\" tab" + Environment.NewLine
                     + "On this page you can find function value in point with known steps." + Environment.NewLine
                     + "Result will be write in file, and you can write from file and look results." + Environment.NewLine
                     + "Also you can build plot with this points."
            };

            var lab4Title = new Label()
            {
                Text = "Lab 4",
                Style = titleStyle
            };
            var lab4Content = new Label()
            {
                Style = contentStyle,
                Text = "You can find this functionality in \"Lab 4\" tab" + Environment.NewLine
                     + "On this page you can work with data base." + Environment.NewLine
                     + "You can creat, read, update, delete functionality." + Environment.NewLine
                     + "Also you can filter rows as you want."
            };

            var lab5Title = new Label()
            {
                Style = titleStyle,
                Text = "Lab 5"
            };
            var lab5Content = new Label()
            {
                Style = contentStyle,
                Text = "You can find this functionality in \"Lab 5\" tab" + Environment.NewLine
                      + "On this page you can find you contacts" + Environment.NewLine
                      + "Also you can find contacs which has '050' in their number"
            };

            var lab6Title = new Label()
            {
                Style = titleStyle,
                Text = "Lab 6"
            };
            var lab6Content = new Label()
            {
                Style = contentStyle,
                Text = "You can find this functionality in \"Lab 6\" tab" + Environment.NewLine
                     + " On this page you can fint your current location or find interesting place" + Environment.NewLine
                     + "Also you can geodecode your coordinates into adress." + Environment.NewLine
                     + "You can fin distance between point and current location."
            };

            stack.Children.Add(lab123Title);
            stack.Children.Add(lab123Content);

            stack.Children.Add(lab4Title);
            stack.Children.Add(lab4Content);

            stack.Children.Add(lab5Title);
            stack.Children.Add(lab5Content);

            stack.Children.Add(lab6Title);
            stack.Children.Add(lab6Content);

            scroll.Content = stack;

            Content = scroll;
        }
    }
}