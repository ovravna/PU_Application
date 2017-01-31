﻿using PU_Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PU_Application.Model
{
    public class MyItem : Item
    {
        public MyItem() 
            : base()
        {
            
        }


        int quantity = 1;
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value;  OnPropertyChanged(); }
        }

    }
}
