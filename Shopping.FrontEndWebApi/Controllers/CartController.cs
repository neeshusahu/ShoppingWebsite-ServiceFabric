using System;
using System.Collections.Generic;
using System.Linq;
using Shopping.Products.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Shopping.FrontEndWebApi.Model;
using UserActor.Interfaces;
using Microsoft.ServiceFabric.Actors.Client;

namespace Shopping.FrontEndWebApi.Controllers
{
    public class CartController: Controller
    {
        [HttpGet("{userId}")]
        public async Task<Cart> Get(string userId)
    {
        IUserActor actor = GetActor(userId);

        Dictionary<Guid, int> products = await actor.GetCart();

        return new Cart()
        {
            UserId = userId,
            Items = products.Select(
                p => new CartItem { ProductId = p.Key.ToString(), Quantity = p.Value }).ToArray()
        };
    }

    [HttpPost("{userId}")]
    public async Task Add(string userId, [FromBody] CartRequest request)
    {
        IUserActor actor = GetActor(userId);

        await actor.AddToCart(request.ProductId, request.Quantity);
    }

   

    private IUserActor GetActor(string userId)
    {
        return ActorProxy.Create<IUserActor>(new Microsoft.ServiceFabric.Actors.ActorId(userId), new Uri("fabric:/Shopping/UserActorService"));
    }
}
}

