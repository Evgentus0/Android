using Laba3.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Laba3
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private double z_parametr, b_parametr, a_parametr;
        private string filePath;
        private Calculator calculator;
        private FileWork fileWorker;
        public MainPage()
        {
            InitializeComponent();
            Title = "Main Page";

            z_parametr = 13;
            b_parametr = 0.000000000423;
            a_parametr = 0.00000324;
            calculator = new Calculator(z_parametr, b_parametr, a_parametr);
            labelParams.Text = $"z = {z_parametr}; b = {b_parametr}; a = {a_parametr}";
            filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "result.txt");
            fileWorker = new FileWork(filePath);
        }

        private async void CalculateAndWriteToFile_click(object sender, EventArgs e)
        {
            if (double.TryParse(inputFrom.Text, out double from) &&
               double.TryParse(inputTo.Text, out double to) &&
               double.TryParse(inputStep.Text, out double step))
            {
                try
                {
                    var result = calculator.GetArgAndExpr(from, to, step);
                    fileWorker.WriteToFile(result, from, to, step);
                    await DisplayAlert("Information", "Data has been written to file", "OK");
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Alarm!", ex.Message, "OK");
                }
            }
            else
            {
                await DisplayAlert("Alarm!", "Incorrect input!", "OK");
            }
        }

        private async void ReadFromFileAsText_click(object sender, EventArgs e)
        {
            try
            {
                var result = fileWorker.ReadFromFile();

                await Navigation.PushAsync(new ResultsView(result));
            }
            catch(Exception ex)
            {
                await DisplayAlert("Alarm!", ex.Message, "OK");
            }
        }

        private async void ViewResultAsPlot_click(object sender, EventArgs e)
        {
            try
            {
                var result = fileWorker.ReadFromFile();

                await Navigation.PushAsync(new ViewPlot(result));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alarm!", ex.Message, "OK");
            }
        }

        private async void Info_Clicked(object sender, EventArgs e)
        {
            var newLine = Environment.NewLine;
            string message = $"My name is Yevhenii Romanenko.{newLine}" +
                             $"I stady in a group TTP-3 on faculty of Computer Science and Cybernetics{newLine}" +
                             $"At the end of this course I would like to get more knowledge about mobile delepopment";
            await DisplayAlert("Information", message, "OK");
        }
    }
}
