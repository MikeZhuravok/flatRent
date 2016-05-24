using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlatRent.Entities
{
    public class Flat : Entity
    {
        [Display(Name ="Number of rooms")]
        public int RoomNumber { set; get; }
        public string Country { set; get; }
        public string City { get; set; }
        public string Address { set; get; }
        public string District { set; get; }
        public string Description { set; get; }
        public List<Facility> Facilities { set; get; }
        [Display(Name = "Price for day")]
        public decimal PriceForDay { set; get; }
        [Display(Name = "Price for month")]
        public decimal PriceForMonth { set; get; }
        
        public double Latitude; //широта
        public double Longitude; //долгота

        public int OwnerId { set; get; }
    }
}