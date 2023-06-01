using Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tour : ContentPage
    {
        TourViewModel viewModel;
        public Tour()
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