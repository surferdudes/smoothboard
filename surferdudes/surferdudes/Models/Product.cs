using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace surferdudes.Models
{
    public class Product
    {
        public int id { get; set; }
        public string naam { get; set; }
        public double prijs { get; set; }
        public string omschrijving { get; set; }
    }
}
