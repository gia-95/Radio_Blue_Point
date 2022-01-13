using Radio_Blue_Point.Data;
using Radio_Blue_Point.Services;
using Radio_Blue_Point.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Radio_Blue_Point
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        public static RecipesDAO database;
        public static RecipesDAO Database
        {
            get
            {
                if (database == null)
                {
                    database = new RecipesDAO();
                }
                return database;
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
