using Mobile.Models;
using Mobile.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mobile.ViewModels
{
    public class FiltersViewModel : INotifyPropertyChanged
    {
        MainPageViewModel mainPageViewModel { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<object> CombinedTours { get; set; }
        public ObservableCollection<string> Destinations { get; set; }
        public ObservableCollection<string> Departures { get; set; }
        public ObservableCollection<string> Types { get; set; }


        public ICommand NavToMainCommand { get; set; }

        public FiltersViewModel(ObservableCollection<object> tours, MainPageViewModel viewModel)
        {
            Departures = new ObservableCollection<string>();
            CombinedTours = tours;
            Destinations = new ObservableCollection<string>();
            Departures = new ObservableCollection<string>();
            Types = new ObservableCollection<string>();

            mainPageViewModel = viewModel;
            //CombinedTours.Clear();


            GetDeparture();
            GetDestinations();
            GetTypes();

            DepartureButtonCommand = new Command(DepartureFilter);
            NavToMainCommand = new Command(NavToMain);


            DepartureButtonColor = Color.FromHex("#FEFEFE");
        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }



        private Color departureButtonColor;
        public ICommand DepartureButtonCommand { get; set; }
        private bool isDepartureSelected;


        public bool IsDepartureSelected
        {
            get { return isDepartureSelected; }
            set
            {
                if (isDepartureSelected != value)
                {
                    isDepartureSelected = value;
                    OnPropertyChanged(nameof(isDepartureSelected));
                    UpdateDepartureButtonColor();
                }
            }
        }

        public Color DepartureButtonColor
        {
            get { return departureButtonColor; }
            set
            {
                if (departureButtonColor != value)
                {
                    departureButtonColor = value;
                    OnPropertyChanged(nameof(DepartureButtonColor));
                }
            }
        }
        private void UpdateDepartureButtonColor()
        {
            DepartureButtonColor = IsDepartureSelected ? Color.FromHex("#FEFEFE") : Color.Black;
        }

        private async void DepartureFilter()
        {
            IsDepartureSelected = !IsDepartureSelected;
        }

        private void GetDestinations()
        {
            foreach (var item in CombinedTours)
            {

                if (item is OrgTour orgTour)
                {
                    if (!Destinations.Contains(orgTour.tour.destination))
                    {
                        string destination = orgTour.tour.destination;
                        Destinations.Add(destination);
                    }
                }
                else if (item is Models.HandTour handTour)
                {
                    if (!Destinations.Contains(handTour.tour.destination))
                    {
                        string destination = handTour.tour.destination;
                        Destinations.Add(destination);
                    }
                }
            }
        }

        private void GetDeparture()
        {
            foreach (var item in CombinedTours)
            {

                if (item is OrgTour orgTour)
                {
                    if (!Departures.Contains(orgTour.tour.placeOfDeparture))
                    {
                        string departure = orgTour.tour.placeOfDeparture;
                        Departures.Add(departure);
                    }
                }
                else if (item is Models.HandTour handTour)
                {
                    if (!Departures.Contains(handTour.tour.placeOfDeparture))
                    {
                        string departure = handTour.tour.placeOfDeparture;
                        Departures.Add(departure);
                    }
                }
            }
        }
        private void GetTypes()
        {
            foreach (var item in CombinedTours)
            {

                if (item is OrgTour orgTour)
                {
                    if (!Types.Contains(orgTour.tour.category))
                    {
                        string type = orgTour.tour.category;
                        Types.Add(type);
                    }
                }
                else if (item is Models.HandTour handTour)
                {
                    if (!Types.Contains(handTour.tour.category))
                    {
                        string type = handTour.tour.category;
                        Types.Add(type);
                    }
                }
            }
        }

        private void NavToMain()
        {
            MainPageViewModel main = new MainPageViewModel(CombinedTours);

            var mainPage = new MainFlyout();
            mainPage.BindingContext = main;
            App.Current.MainPage = mainPage;
        }
    }
}
