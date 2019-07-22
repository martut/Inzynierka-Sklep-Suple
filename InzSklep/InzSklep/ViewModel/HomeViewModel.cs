using InzSklep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InzSklep.ViewModel
{
    public class HomeViewModel
    {
        public IEnumerable<Product> BestSeller { get; set; }

        public IEnumerable<Product> Newest { get; set; }

        public IList<HotOffer> OfferSlider { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        public IEnumerable<Producer> Producers { get; set; }
    }
}