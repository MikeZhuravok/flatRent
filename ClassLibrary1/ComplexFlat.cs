using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FlatRent.Entities
{
    public class ComplexFlat 
        // Flat with multiselect (at least)
    {
        public Flat Flat { get; set; }

        public MultiSelectList FacilitiesSelection { set; get; }
    }
}
