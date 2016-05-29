using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatRent.Entities
{
    public class Picture : Entity
    {
        public string Name { get; set; }
        public string LinkToImage { get; set; }


        public int FlatId { set; get; }

        public virtual Flat Flat { set; get; }
    }
}
