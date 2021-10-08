using System;
using System.Collections.Generic;
using MarketNetwork.Models;


namespace MarketNetwork.ProductData
{
   public interface IProductData
    {
        List<Product> GetProducts();

        Product GetProduct(Guid Id);

        Product AddProduct(Product product);

        void DeleteProduct(Product product);

        Product EditProduct(Product product);


    }
}
