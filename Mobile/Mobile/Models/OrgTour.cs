using System;
using System.Collections.Generic;
using System.Text;

namespace Mobile.Models
{
    public class OrgTour
    {
        public int Id { get; set; }
        public int price { get; set; }
        public int experience { get; set; }
        public string promocode { get; set; }
        public User user { get; set; }
        public Tour tour { get; set; }
    }
}
