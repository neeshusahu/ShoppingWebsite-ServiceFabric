using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.FrontEndWebApi.Model
{
    public class ProductStatus
    {
        public Guid ProductID { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }
        public bool isAvailable { get; set; }
    }
}
