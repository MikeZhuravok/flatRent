using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlatRent.Entities
{
    public class Flat : Entity
    {
        public int RoomNumber { set; get; }
        public string Country { set; get; }
        public string City { get; set; }
        public string Address { set; get; }
        public string District { set; get; }
        public string Description { set; get; }
        public List<Facility> Facilities { set; get; }
        public decimal PriceForDay { set; get; }
        public decimal PriceForMonth { set; get; }

        public int OwnerId { set; get; }
    }
}