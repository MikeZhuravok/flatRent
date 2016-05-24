using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlatRent.Entities
{
    public class Facility : Entity
    {
        public string Type { get; set; }
        public string Description { set; get; }
        //Kitchen, Bathroom, WiFi, TV, Hairdryer, Iron, Fridge, Microwave, Kettle, Dishes, Linens
    }
}