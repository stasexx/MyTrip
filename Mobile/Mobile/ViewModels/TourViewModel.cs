using Mobile.MobileServices;
using Mobile.Models;
using System.ComponentModel;
using System.Threading.Tasks;


namespace Mobile.ViewModels
{
    public class TourViewModel : INotifyPropertyChanged
    {
        private bool initialized = false;
        private bool isBusy;
        private Tour tour;

        public Tour Tour
        {
            get { return tour; }
            set
            {
                tour = value;
                OnPropertyChanged(nameof(Tour));
            }
        }

        private OneTourService oneTourService;

        public event PropertyChangedEventHandler PropertyChanged;

        public TourViewModel()
        {
            oneTourService = new OneTourService();
        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public async Task GetTour()
        {
            if (initialized)
                return;

            isBusy = true;

            Tour result = await oneTourService.GetTour();
            Tour = result;

            isBusy = false;
            initialized = true;
        }
    }
}
