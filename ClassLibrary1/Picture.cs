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
        public byte[] Image { get; set; }
    }
}
