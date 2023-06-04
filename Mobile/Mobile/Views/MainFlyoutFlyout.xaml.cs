using Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainFlyoutFlyout : ContentPage
    {
        public ListView ListView;

        public MainFlyoutFlyout()
        {
            InitializeComponent();

            BindingContext = new MainFlyoutFlyoutViewModel();

        }

        private class MainFlyoutFlyoutViewModel : INotifyPropertyChanged
        {


            public ICommand NavToProfileCommand { get; private set; }
            public ICommand NavToSupportCommand { get; private set; }

            public MainFlyoutFlyoutViewModel()
            {
                NavToProfileCommand = new Command(NavToProfile);
                NavToSupportCommand = new Command(NavToSupport);

            }

            private void NavToProfile()
            {
                App.Current.MainPage = new Views.Profile();
            }
            private void NavToSupport()
            {
                App.Current.MainPage = new Views.Support();
            }


            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}