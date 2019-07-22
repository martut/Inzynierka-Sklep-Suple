using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InzSklep.Models
{
    public class HotOffer
    {
        public int HotOfferId { get; set; }
        public string OfferIMGFile { get; set; }
        public string OfferLINQ { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}