using System;
using System.Collections.Generic;
using System.Text;

namespace Mobile.Models
{
    public class Tour
    {
        public int TourId { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public float rate { get; set; }

        public string typeOfTour { get; set; }

        public string category { get; set; }

        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }

        public string destination { get; set; }

        public string placeOfDeparture { get; set; }

        public int countOfUser { get; set; }

        public string mainPhoto { get; set; }

        public string allPhotos { get; set; }

        public string tags { get; set; }
        public string rateImage
        {
            get
            {
                string image;
                switch (rate)
                {
                    case 1:
                        image = "OneStar.png";
                        break;
                    case 2:
                        image = "TwoStars.png";
                        break;
                    case 3:
                        image = "ThreeStars.png";
                        break;
                    case 4:
                        image = "FourStars.png";
                        break;
                    case 5:
                        image = "FiveStars.png";
                        break;
                    default:
                        image = "ZeroStars.png";
                        break;
                }

                return image;
            }
        }


    }
}
