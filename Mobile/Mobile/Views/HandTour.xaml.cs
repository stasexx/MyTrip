using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HandTour : ContentPage
	{
        TourViewModel viewModel;
        public HandTour()
        {
            InitializeComponent();
            //viewModel = new TourViewModel();
            //BindingContext = viewModel;


        }

        protected override async void OnAppearing()
        {
            //await viewModel.GetTour();
            //base.OnAppearing();
        }
    }
}