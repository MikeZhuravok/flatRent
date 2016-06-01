using FlatRent.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Objects;

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
        [Display(Name = "Price for day")]
        public decimal PriceForDay { set; get; }
        [Display(Name = "Price for month")]
        public decimal PriceForMonth { set; get; }
        public double Latitude { set; get; } //широта
        public double Longitude { set; get; } //долгота
        public int ZipCode { set; get; }
        public string OwnerId { set; get; } // applicationUser id -> string

        //[ObjectContextOptions.LazyLoadingEnabled = false]
        public virtual List<Picture> Pictures { set; get; }
        public virtual List<FacilityInFlat> Facilities { set; get; }
        public virtual ApplicationUser ApplicationUser { set; get; }
    }
}