using Laba4_DB.Helpers;
using Laba4_DB.Interfaces;
using Laba4_DB.Models;
using Laba4_DB.Views;
using Laba4_DB.Views.Contacts;
using Laba4_DB.Views.DataBase;
using Laba4_DB.Views.ExpressionAndPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Laba4_DB
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();

        private readonly ICarRepository carRepository;
        public MainPage(ICarRepository carRepository)
        {
            InitializeComponent();
            this.carRepository = carRepository;

            MasterBehavior = MasterBehavior.Popover;

        }
        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Lab123:
                        MenuPages.Add(id, new NavigationPage(new Lab3Main()));
                        break;
                    case (int)MenuItemType.Lab4:
                        MenuPages.Add(id, new NavigationPage(new DataBaseMain(carRepository)));
                        break;
                    case (int)MenuItemType.Lab5:
                        MenuPages.Add(id, new NavigationPage(new ContactsMain()));
                        break;
                    //case (int)MenuItemType.Lab6:
                    //    MenuPages.Add(id, new NavigationPage(new ContactsPage()));
                    //    break;
                    //case (int)MenuItemType.About:
                    //    MenuPages.Add(id, new NavigationPage(new AboutPage()));
                    //    break;
                    //case (int)MenuItemType.Help:
                    //    MenuPages.Add(id, new NavigationPage(new SummuriesPage()));
                    //    break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }

    }
}
