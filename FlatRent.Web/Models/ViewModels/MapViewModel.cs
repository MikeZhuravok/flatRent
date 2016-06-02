using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlatRent.Web.Models.ViewModels
{
    public class MapViewModel
    {
        public string Latitude { set; get; }
        public string Longitude { set; get; }
        public string Address { set; get; }
        //public string Url { set; get; }
        public decimal PriceForDay { set; get; }
        public decimal PriceForMonth { set; get; }
    }
}