﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Mobile.Views;
using Mobile.MobileServices;

namespace Mobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            //MainPage = new MainFlyout();

            //MainPage = new NavigationPage(new Views.GetStarted());

            //MainPage = new NavigationPage(new Views.SignIn());

            //MainPage = new NavigationPage(new Views.Register());

            //MainPage = new NavigationPage(new Views.Profile());

            MainPage = new NavigationPage(new Views.Tour());
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
