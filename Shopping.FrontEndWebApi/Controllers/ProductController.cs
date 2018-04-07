using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shopping.Products.Models;
using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using Shopping.FrontEndWebApi.Model;

namespace Shopping.FrontEndWebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        // GET api/values
        private readonly IProductRepositoryCommon _catalogService;

        public ProductController()
        {
            _catalogService = ServiceProxy.Create<IProductRepositoryCommon>(
                new Uri("fabric:/Shopping/Product"),
                new ServicePartitionKey(0));
        }

        [HttpGet]
        public async Task<IEnumerable<ProductStatus>> Get()
        {
            IEnumerable<Shopping.Products.Models.Products> allProducts = await _catalogService.GetAllProduct();

            return allProducts.Select(p => new ProductStatus
            {
                ProductID = p.ProductID,
                Name = p.Name,

                Price = p.Price,
                isAvailable = p.Availability > 0
            });
        }
        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
