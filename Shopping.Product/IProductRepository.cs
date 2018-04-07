using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shopping.Products.Models;

namespace Shopping.Product
{
    interface IProductRepository
    {
        Task<IEnumerable<Shopping.Products.Models.Products>> GetAllProducts();
        Task AddProduct(Shopping.Products.Models.Products p);
        

    }
}
