using Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainFlyoutDetail : ContentPage
    {
        public MainPageViewModel viewModel;
        public MainFlyoutDetail()
        {
            InitializeComponent();

            viewModel = new MainPageViewModel();
            BindingContext = viewModel;
        }
        public MainFlyoutDetail(MainPageViewModel modelView)
        {
            InitializeComponent();

            viewModel = modelView;
            BindingContext = viewModel;
        }

        private void ShowFlyoutMenu(object sender, EventArgs e)
        {
            // Open the flyout menu
            (App.Current.MainPage as FlyoutPage).IsPresented = true; 
        }

        protected override async void OnAppearing()
        {
            //await viewModel.GetTours();
            await viewModel.GetOrgTours();
            await viewModel.GetHandTours();
            base.OnAppearing();
        }

    }
}