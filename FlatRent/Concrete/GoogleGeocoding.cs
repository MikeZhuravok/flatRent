using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml.Linq;

namespace FlatRent.Concrete
{
    public static class GoogleGeocoding
    {
        public static void FromAddressToCoordinates(string address, out double lat, out double lng)
        {
            var requestUri = string.Format("http://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=false", Uri.EscapeDataString(address));

            var request = WebRequest.Create(requestUri);
            var response = request.GetResponse();
            var xdoc = XDocument.Load(response.GetResponseStream());

            var result = xdoc.Element("GeocodeResponse").Element("result");
            var locationElement = result.Element("geometry").Element("location");
            lat = Double.Parse(locationElement.Element("lat").ToString());
            lng = Double.Parse(locationElement.Element("lng").ToString());
        }
    }
}