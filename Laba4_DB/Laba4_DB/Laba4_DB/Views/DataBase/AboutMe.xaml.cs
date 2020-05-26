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
    public partial class AboutMe : ContentPage
    {
        public AboutMe()
        {
            
            InitializeComponent();
            Title = "Stident's information";

            myPhoto.Source = "MyPhoto.jpg";
            aboutMe.Text =  $"My name is Yevhenii Romanenko.{Environment.NewLine}" +
                            $"I stady in a group TTP-3 on faculty of Computer Science and Cybernetics{Environment.NewLine}" +
                            $"At the end of this course I would like to get more knowledge about mobile delepopment";

        }
    }
}