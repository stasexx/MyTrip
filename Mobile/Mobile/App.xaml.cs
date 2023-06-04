using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Mobile.Views;
using Mobile.MobileServices;
using Xamarin.Essentials;
using System.Net.Http.Headers;

namespace Mobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            //bool isFirsRun = !Preferences.ContainsKey("isFirstRun");

            //if (isFirsRun)
            //{
            //    MainPage = new GetStarted();
            //    Preferences.Set("isFirstRun", false);
            //}
            //else
            //{
            //    MainPage = new SignIn();

            //}
            MainPage = new GetStarted();

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
