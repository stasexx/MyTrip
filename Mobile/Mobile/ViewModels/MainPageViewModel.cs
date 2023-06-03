using Mobile.MobileServices;
using Mobile.Models;
using Mobile.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;


namespace Mobile.ViewModels
{
    public class MainPageViewModel: INotifyPropertyChanged
    {



        private bool isOfficialSelected;
        private bool isHandmadeSelected;
        private bool isBestSelected;


        private Color buttonTextColor;
        private Color boxColor;
       // private Color departureButtonColor;
       // private Color textDepartureColor;


        public ObservableCollection<object> CombinedTours { get; set; }
        public ObservableCollection<Tour> Tours { get; set; }
        public ObservableCollection<OrgTour> OrgTours { get; set; }
        public ObservableCollection<OrgTour> HandTours { get; set; }


        public ICommand OfficialButtonCommand { get; set; }
        public ICommand HandmadeButtonCommand { get; set; }
        public ICommand BestButtonCommand { get; set; }
        public ICommand NavToFiltersCommand { get; set; }




        readonly TourService TourService = new TourService();
        public event PropertyChangedEventHandler PropertyChanged;

        public MainPageViewModel() 
        {

            CombinedTours = new ObservableCollection<object>();
            Tours = new ObservableCollection<Tour>();
            OrgTours = new ObservableCollection<OrgTour>();
            HandTours = new ObservableCollection<OrgTour>();

            OfficialButtonCommand = new Command(ChangeOfficialSelection);
            HandmadeButtonCommand = new Command(ChangeHandmadeSelection);
            BestButtonCommand = new Command(ChangeBestSelection);
            NavToFiltersCommand = new Command(NavToFilters);


            ButtonOffTextColor = Color.FromHex("#5F5F5F");
            ButtonHandTextColor = Color.FromHex("#5F5F5F");
            ButtonBestTextColor = Color.FromHex("#5F5F5F");
            OffBoxColor = Color.Black;
            HandBoxColor = Color.Black;
            BestBoxColor = Color.Black;

        }

        public MainPageViewModel(ObservableCollection<object> tours)
        {

            CombinedTours = new ObservableCollection<object>();
            Tours = new ObservableCollection<Tour>();
            OrgTours = new ObservableCollection<OrgTour>();
            HandTours = new ObservableCollection<OrgTour>();


            OfficialButtonCommand = new Command(ChangeOfficialSelection);
            HandmadeButtonCommand = new Command(ChangeHandmadeSelection);
            BestButtonCommand = new Command(ChangeBestSelection);
            NavToFiltersCommand = new Command(NavToFilters);

            ButtonOffTextColor = Color.FromHex("#5F5F5F");
            ButtonHandTextColor = Color.FromHex("#5F5F5F");
            ButtonBestTextColor = Color.FromHex("#5F5F5F");
            OffBoxColor = Color.Black;
            HandBoxColor = Color.Black;
            BestBoxColor = Color.Black;

            CombinedTours = tours;
        }

        private void NavToFilters()
        {
            FiltersViewModel filtersViewModel = new FiltersViewModel(CombinedTours, this);
            var filtersPage = new Filter(filtersViewModel);
            App.Current.MainPage = filtersPage;
        }


        public bool IsOfficialSelected
        {
            get { return isOfficialSelected; }
            set
            {
                if(isOfficialSelected != value)
                {
                    isOfficialSelected = value;
                    OnPropertyChanged(nameof(IsOfficialSelected));
                    UpdateOffButtonColor();
                    UpdateOffBoxColor();
                }
            }
        }
        public bool IsHandmadeSelected
        {
            get { return isHandmadeSelected; }
            set
            {
                if (isHandmadeSelected != value)
                {
                    isHandmadeSelected = value;
                    OnPropertyChanged(nameof(isHandmadeSelected));
                    UpdateHandButtonColor();
                    UpdateHandBoxColor();
                }
            }
        }

        public bool IsBestSelected
        {
            get { return isBestSelected; }
            set
            {
                if (isBestSelected != value)
                {
                    isBestSelected = value;
                    OnPropertyChanged(nameof(isBestSelected));
                    UpdateBestButtonColor();
                    UpdateBestBoxColor();
                }
            }
        }


        private async void ChangeOfficialSelection()
        {
            if (IsHandmadeSelected)
            {
                ChangeHandmadeSelection();
            }
            if (IsBestSelected)
            {
                ChangeBestSelection();
            }

            IsOfficialSelected = !IsOfficialSelected;

            if (IsOfficialSelected)
            {

                CombinedTours.Clear();
                await GetOrgTours();

                OnPropertyChanged(nameof(CombinedTours));
            }
            else
            {
                CombinedTours.Clear();
                await GetOrgTours();
                await GetHandTours();
            }
        }

        private async void ChangeHandmadeSelection()
        {
            if (IsOfficialSelected)
            {
                ChangeOfficialSelection();
            }
            if (IsBestSelected)
            {
                ChangeBestSelection();
            }

            IsHandmadeSelected = !IsHandmadeSelected;

            if (IsHandmadeSelected)
            {

                CombinedTours.Clear();
                await GetHandTours();

                OnPropertyChanged(nameof(CombinedTours));
            }
            else
            {
                CombinedTours.Clear();
                await GetOrgTours();
                await GetHandTours();
            }
        }
        

        private  void ChangeBestSelection()
        {
            if (IsOfficialSelected)
            {
                ChangeOfficialSelection();
            }
            if (IsHandmadeSelected)
            {
                ChangeHandmadeSelection();
            }

            IsBestSelected = !IsBestSelected;
            if (IsBestSelected)
            {

                SortCombinedToursByRateDescending();

                OnPropertyChanged(nameof(CombinedTours));
            }
            else
            {
                ShuffleCombinedTours();
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }




        // Get data from api

        // Get all tours
        public async Task GetTours()
        {

            IEnumerable<Tour> tours = await TourService.GetTours();

            while (Tours.Any())
                Tours.RemoveAt(Tours.Count - 1);

            foreach (Tour tour in tours)
                Tours.Add(tour);
        }

        // Get all orgTours
        public async Task GetOrgTours()
        {

            IEnumerable<OrgTour> orgTours = await TourService.GetOrgTours();

            foreach (OrgTour orgTour in orgTours)
                CombinedTours.Add(orgTour);

            ShuffleCombinedTours();
        }

        // Get all handTours
        public async Task GetHandTours()
        {

            IEnumerable<HandTour> handTours = await TourService.GetHandTours();

            foreach (HandTour handTour in handTours)
                CombinedTours.Add(handTour);

            ShuffleCombinedTours();
        }

        // Shuffle all data
        private void ShuffleCombinedTours()
        {
            List<object> tempList = CombinedTours.ToList();
            Random random = new Random();

            for (int i = tempList.Count - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);
                (tempList[j], tempList[i]) = (tempList[i], tempList[j]);
            }

            CombinedTours.Clear();
            foreach (var item in tempList)
                CombinedTours.Add(item);
        }

        private void SortCombinedToursByRateDescending()
        {
            List<object> tempList = CombinedTours.ToList();
            tempList.Sort((x, y) =>
            {
                double rateX = 0;
                double rateY = 0;

                if (x is OrgTour orgTourX)
                    rateX = orgTourX.tour.rate;
                else if (x is HandTour handTourX)
                    rateX = handTourX.tour.rate;

                if (y is OrgTour orgTourY)
                    rateY = orgTourY.tour.rate;
                else if (y is HandTour handTourY)
                    rateY = handTourY.tour.rate;

                return rateY.CompareTo(rateX);
            });

            CombinedTours.Clear();
            foreach (var item in tempList)
                CombinedTours.Add(item);
        }


        //Update Colors

        public Color ButtonOffTextColor
        {
            get { return buttonTextColor; }
            set
            {
                if (buttonTextColor != value)
                {
                    buttonTextColor = value;
                    OnPropertyChanged(nameof(ButtonOffTextColor));
                }
            }
        }
        public Color ButtonHandTextColor
        {
            get { return buttonTextColor; }
            set
            {
                if (buttonTextColor != value)
                {
                    buttonTextColor = value;
                    OnPropertyChanged(nameof(ButtonHandTextColor));
                }
            }
        }

        public Color ButtonBestTextColor
        {
            get { return buttonTextColor; }
            set
            {
                if (buttonTextColor != value)
                {
                    buttonTextColor = value;
                    OnPropertyChanged(nameof(ButtonBestTextColor));
                }
            }
        }

        public Color OffBoxColor
        {
            get { return boxColor; }
            set
            {
                if (boxColor != value)
                {
                    boxColor = value;
                    OnPropertyChanged(nameof(OffBoxColor));
                }
            }
        }

        public Color HandBoxColor
        {
            get { return boxColor; }
            set
            {
                if (boxColor != value)
                {
                    boxColor = value;
                    OnPropertyChanged(nameof(HandBoxColor));
                }
            }
        }

        public Color BestBoxColor
        {
            get { return boxColor; }
            set
            {
                if (boxColor != value)
                {
                    boxColor = value;
                    OnPropertyChanged(nameof(BestBoxColor));
                }
            }
        }




        private void UpdateOffButtonColor()
        {
            ButtonOffTextColor = IsOfficialSelected ? Color.Black : Color.FromHex("#5F5F5F");
        }
        private void UpdateHandButtonColor()
        {
            ButtonHandTextColor = IsHandmadeSelected ? Color.Black : Color.FromHex("#5F5F5F");
        }
        private void UpdateBestButtonColor()
        {
            ButtonBestTextColor = IsBestSelected ? Color.Black : Color.FromHex("#5F5F5F");
        }


        private void UpdateOffBoxColor()
        {
            OffBoxColor = IsOfficialSelected ? Color.FromHex("#FFA800") : Color.Black;
        }
        private void UpdateHandBoxColor()
        {
            HandBoxColor = IsHandmadeSelected ? Color.FromHex("#FFA800") : Color.Black;
        }
        private void UpdateBestBoxColor()
        {
            BestBoxColor = IsBestSelected ? Color.FromHex("#FFA800") : Color.Black;
        }

    }
}
