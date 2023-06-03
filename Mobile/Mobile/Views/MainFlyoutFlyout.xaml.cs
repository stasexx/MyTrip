using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
            public ObservableCollection<MainFlyoutFlyoutMenuItem> MenuItems { get; set; }

            public MainFlyoutFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<MainFlyoutFlyoutMenuItem>(new[]
                {
                    new MainFlyoutFlyoutMenuItem { Id = 0, Title = "Page 1" },
                    new MainFlyoutFlyoutMenuItem { Id = 1, Title = "Page 2" },
                    new MainFlyoutFlyoutMenuItem { Id = 2, Title = "Page 3" },
                    new MainFlyoutFlyoutMenuItem { Id = 3, Title = "Page 4" },
                    new MainFlyoutFlyoutMenuItem { Id = 4, Title = "Page 5" },
                });
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