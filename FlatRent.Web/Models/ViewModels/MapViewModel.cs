using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlatRent.Web.Models.ViewModels
{
    public class MapViewModel
    {
        public double Latitude { set; get; }
        public double Longitude { set; get; }
        public string Address { set; get;  }
        public string Url { set; get; }
    }
}