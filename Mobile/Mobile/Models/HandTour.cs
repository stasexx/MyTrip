﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Mobile.Models
{
    public class HandTour
    {
        public int Id { get; set; }
        public Tour tour { get; set; }
        public User user { get; set; }
    }
}