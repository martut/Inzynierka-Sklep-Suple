﻿using InzSklep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InzSklep.ViewModel
{
    public class CartViewModel
    {
        public List<CartItem> CartItem { get; set; }
        public decimal TotalPrice { get; set; }
    }
}