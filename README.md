# ShoppingWebsite-ServiceFabric
An Ecommerce microservice application using Actor Programming Model with Azure ServiceFabric

The solution consists of following
-  Shopping
   - Service Fabric Application
- Shopping.FrontEndWebApi
   - ASP.NET Core 1.1 Web Api  reliable stateless Service
 - Shopping.Product
   - A reliable stateful service for product catalog
  - Shopping.Products.Models
    - Common interface project
   - UserActor
     - Actor Service for users implementation
    - UserActor.Interfaces
      - Common interface for User Actor Service
      
  # Getting Started
  
  Make sure to have following in place for solution build
  - Visual Studio 2017
  - Azure Service Fabric SDK
  
  
