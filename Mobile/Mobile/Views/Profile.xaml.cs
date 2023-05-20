﻿using Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Profile : ContentPage
    {
        ProfileViewModel viewModel;
        public Profile()
        {
            InitializeComponent();

            viewModel = new ProfileViewModel();
            BindingContext =  viewModel;
        }

        protected override async void OnAppearing()
        {
            await viewModel.GetUser();
            base.OnAppearing();
        }

    }
}