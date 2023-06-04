using Mobile.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Mobile.ViewModels
{
    public class HandTourViewModel : INotifyPropertyChanged
    {
        public Models.HandTour HandTour { get; set; }
        public ICommand NavToMainCommand { get; private set; }
        public ICommand ShareCommand { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public HandTourViewModel(Models.HandTour handTour)
        {
            HandTour = handTour;
            DecodeUrl();
            //HandTour.tour.startDate = HandTour.tour.startDate.Date;
            //HandTour.tour.endDate = HandTour.tour.endDate.Date;

            NavToMainCommand = new Command(NavToMain);
            ShareCommand = new Command(Share);
        }

        private void DecodeUrl()
        {
            HandTour.tour.mainPhoto = WebUtility.UrlDecode(HandTour.tour.mainPhoto);
        }
        private void NavToMain()
        {

            MainPageViewModel main = new MainPageViewModel();
            var mainPage = new MainFlyout();
            mainPage.BindingContext = main;
            App.Current.MainPage = mainPage;
        }
        private async void Share()
        {
            await Xamarin.Essentials.Share.RequestAsync(new ShareTextRequest
            {
                Subject = "MyTrip",
                Text = $"See what tour i found in the MyTripp app.\n Tour to {HandTour.tour.name}.",
            });
        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
