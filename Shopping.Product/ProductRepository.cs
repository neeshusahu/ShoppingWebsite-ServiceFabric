using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Data;
using Microsoft.ServiceFabric.Data.Collections;
using System.Threading;
using Shopping.Products.Models;

namespace Shopping.Product
{
    class ProductRepository:IProductRepository

    {
        private IReliableStateManager _stateManager;
        private object cancellationToken;
        public ProductRepository(IReliableStateManager sm)
        {
            _stateManager = sm;
        }

        public async Task<IEnumerable<Shopping.Products.Models.Products>> GetAllProducts()
        {
            var products = await _stateManager.GetOrAddAsync<IReliableDictionary<Guid, Shopping.Products.Models.Products>>("products");
            var result = new List<Shopping.Products.Models.Products>();
            using (var tx = _stateManager.CreateTransaction())
            {
                var allProducts= await products.CreateEnumerableAsync(tx, EnumerationMode.Unordered);
                using (var enumerator = allProducts.GetAsyncEnumerator())
                {
                    while (await enumerator.MoveNextAsync(CancellationToken.None))
                    {
                        KeyValuePair<Guid, Shopping.Products.Models.Products> current = enumerator.Current;
                        result.Add(current.Value);
                    }
                }
            }

            return result;
        }
        public async Task AddProduct(Shopping.Products.Models.Products p)
        {
            var products = await _stateManager.GetOrAddAsync<IReliableDictionary<Guid, Shopping.Products.Models.Products>>("products");
            using (var tx = _stateManager.CreateTransaction())
            {
                await products.AddOrUpdateAsync(tx, p.ProductID, p, (ProductID, value) => p);
                await tx.CommitAsync();
            }
        }

        }
    }

