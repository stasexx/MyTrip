using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Mobile.Views;

namespace Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();

            //MainPage = new NavigationPage(new Views.GetStarted());

            //MainPage = new NavigationPage(new Views.SignIn());

            //MainPage = new NavigationPage(new Views.Register());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
