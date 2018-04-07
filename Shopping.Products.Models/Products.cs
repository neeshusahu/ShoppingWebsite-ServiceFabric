using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Products.Models
{
    public class Products
    {
        public Guid ProductID { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }
        public int Availability { get; set; }
    }
}
