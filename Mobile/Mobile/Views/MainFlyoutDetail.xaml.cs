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
    public partial class MainFlyoutDetail : ContentPage
    {
        public MainFlyoutDetail()
        {
            InitializeComponent();
        }

        private void ShowFlyoutMenu(object sender, EventArgs e)
        {
            (App.Current.MainPage as FlyoutPage).IsPresented = true; // Open the flyout menu
        }

    }
}