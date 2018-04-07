using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Data.Collections;
using Shopping.Products.Models;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using Microsoft.ServiceFabric.Services.Remoting.Runtime;

namespace Shopping.Product
{
    /// <summary>
    /// An instance of this class is created for each service replica by the Service Fabric runtime.
    /// </summary>
    internal sealed class Product : StatefulService, IProductRepositoryCommon
    {
        private IProductRepository _repository;
        public Product(StatefulServiceContext context)
            : base(context)
        { }

        public async Task AddProduct(Products.Models.Products p)
        {
            await _repository.AddProduct(p);
        }

        public async Task<IEnumerable<Products.Models.Products>> GetAllProduct()
        {
            return await _repository.GetAllProducts();
        }

        /// <summary>
        /// Optional override to create listeners (e.g., HTTP, Service Remoting, WCF, etc.) for this service replica to handle client or user requests.
        /// </summary>
        /// <remarks>
        /// For more information on service communication, see https://aka.ms/servicefabricservicecommunication
        /// </remarks>
        /// <returns>A collection of listeners.</returns>
        protected override IEnumerable<ServiceReplicaListener> CreateServiceReplicaListeners()
        {
            return new[]
           {
                new ServiceReplicaListener(context => this.CreateServiceRemotingListener(context))
            };
        }

        /// <summary>
        /// This is the main entry point for your service replica.
        /// This method executes when this replica of your service becomes primary and has write status.
        /// </summary>
        /// <param name="cancellationToken">Canceled when Service Fabric needs to shut down this service replica.</param>
        protected override async Task RunAsync(CancellationToken cancellationToken)
        {
            // TODO: Replace the following sample code with your own logic 
            //       or remove this RunAsync override if it's not needed in your service.
            _repository = new ProductRepository(this.StateManager);

            var product1 = new Shopping.Products.Models.Products
            {
                ProductID = Guid.NewGuid(),
                Name = " Monitor",
           
                Price = 500,
                Availability = 100
            };

           
            await _repository.AddProduct(product1);
            var p = _repository.GetAllProducts();

        }
        }
    }

