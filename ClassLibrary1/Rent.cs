using FlatRent.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatRent.Entities
{
    public class Rent : Entity
    {
        public ApplicationUser RentingUser { set; get; }
        public int FlatId { set; get; }
        [DataType(DataType.Date)]     
        public DateTime StartOfRent { set; get; }
        [DataType(DataType.Date)]
        public DateTime EndOfRent { set; get; }

        public virtual ApplicationUser User { set; get; }
        public virtual Flat Flat { set; get; }
    }
}
