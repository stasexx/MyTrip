﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Views
{
    public class MainFlyoutFlyoutMenuItem
    {
        public MainFlyoutFlyoutMenuItem()
        {
            TargetType = typeof(MainFlyoutFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}