using Mobile.MobileServices;
using Mobile.Models;
using Mobile.Views;
using System.ComponentModel;
using System.Net;
using System.Security.Authentication;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Mobile.ViewModels
{
    public class TourViewModel : INotifyPropertyChanged
    {
        public OrgTour OrgTour { get; set; }
        public ICommand NavToMainCommand { get; private set; }
        public ICommand ShareCommand { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public TourViewModel(OrgTour orgTour)
        {
            OrgTour = orgTour;
            OrgTour.tour.startDate = OrgTour.tour.startDate.Date;
            OrgTour.tour.endDate = OrgTour.tour.endDate.Date;
            DecodeUrl();

            NavToMainCommand = new Command(NavToMain);
            ShareCommand = new Command(Share);
        }

        private void DecodeUrl()
        {
            OrgTour.tour.mainPhoto = WebUtility.UrlDecode(OrgTour.tour.mainPhoto);
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
                Text = $"See what tour i found in the MyTripp app.\n Tour to {OrgTour.tour.name} for only {OrgTour.price} $.",
            }); 
        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }


    }
}
