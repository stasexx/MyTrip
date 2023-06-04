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
        public Tour(TourViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }

    }
}