using p4.View;
using p4.Data;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace p4
{
    public partial class App : Application
    {
        public static ProductManager TodoManager { get; private set; }
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            TodoManager = new ProductManager(new RestService());
            MainPage = new NavigationPage(new ProductsListPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
