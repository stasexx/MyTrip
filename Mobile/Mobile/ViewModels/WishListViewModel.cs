using Mobile.MobileServices;
using Mobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.ViewModels
{
    internal class WishListViewModel : INotifyPropertyChanged
    {
        bool initialized = false;
        private bool isBusy;

        public ObservableCollection<Tour> Tours { get; set; } = new ObservableCollection<Tour>();
        TourService TourService = new TourService();
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public async Task GetTours()
        {
            if (initialized == true) return;
            isBusy = true;
            IEnumerable<Tour> tours = await TourService.GetTours();

            while (Tours.Any())
                Tours.RemoveAt(Tours.Count - 1);

            foreach (Tour tour in tours)
                Tours.Add(tour);
            isBusy = false;
            initialized = true;
        }

    }
}