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
    public partial class AboutMe : ContentPage
    {
        public AboutMe()
        {
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            StackLayout stack = new StackLayout();

            var image = new Image() 
            { 
                Source = "Eugene.jpg",
                HorizontalOptions = LayoutOptions.Center,

                WidthRequest = 250,
                HeightRequest = 300,
                Aspect = Aspect.AspectFill,
                Margin = new Thickness(0, 2)
            };

            stack.Children.Add(image);

            var label = new Label()
            {
                Text = "Hi everyone. My name is Eugene Romanenko." + Environment.NewLine
                    + "I am third year student from TTP-3 group." + Environment.NewLine
                    + "This is my final project, y can find all function in slide left menu" + Environment.NewLine
                    + "If you will have any questions you can check \"Help\" tab or chat me to zerom2016romanenko@gmail.com",
                Margin = 10
            };

            stack.Children.Add(label);

            Content = stack;
        }
    }
}