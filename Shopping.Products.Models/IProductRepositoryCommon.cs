using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Products.Models
{
  public  interface IProductRepositoryCommon:IService
    {
        Task<IEnumerable<Products>> GetAllProduct();
        Task AddProduct(Products p);
    }
}
