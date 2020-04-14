using Laba3.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Laba3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultsView : ContentPage
    {
        public ResultsView(string data)
        {
            InitializeComponent();
            Title = "Result Page";

            var points = Parser.Parse(data);

            InitPage(points);
        }

        private void InitPage(Dictionary<double, double> points)
        {
            StackLayout stackLayout = new StackLayout();
            int count = 1;
            foreach (var k in points)
            {
                Label label = new Label
                {
                    Text = $"{count}. {k.Key}: {k.Value}",
                    FontSize = 18
                };
                stackLayout.Children.Add(label);
                count++;
            }
            ScrollView scrollView = new ScrollView();
            scrollView.Content = stackLayout;
            this.Content = scrollView;
        }
    }
}