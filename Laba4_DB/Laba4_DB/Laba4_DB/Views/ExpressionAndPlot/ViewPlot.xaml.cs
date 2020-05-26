using Laba3.BLL;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DataPoint = OxyPlot.DataPoint;

namespace Laba3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewPlot : ContentPage
    {
        public ViewPlot(string data)
        {
            InitializeComponent();
            this.Title = "Plot of function";

            InitPlot(data);
        }

        private void InitPlot(string pointsAsString)
        {
            var points = Parser.Parse(pointsAsString);

            var dataPoints = points.Select<KeyValuePair<double, double>, DataPoint>(x => new DataPoint(x.Key, x.Value));

            BuildPlot(dataPoints);
        }

        private void BuildPlot(IEnumerable<DataPoint> points)
        {
            var lineSeries = new LineSeries();
            lineSeries.Points.AddRange(points);

            var myModel = new PlotModel();

            myModel.Series.Add(lineSeries);

            this.plotView.Model = myModel;
        }
    }
}