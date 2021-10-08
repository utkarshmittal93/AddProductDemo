using MarketNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarketNetwork.ProductData
{
    public class MockProductData : IProductData
    {

        private List<Product> products = new List<Product>()
        {

            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Dell Laptop"
            },
             new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Hp Laptop"
            }
        };

        public Product AddProduct(Product product)
        {
            product.Id = Guid.NewGuid();
            products.Add(product);
            return product;
        }

        public void DeleteProduct(Product product)
        {
            products.Remove(product);
        }

        public Product EditProduct(Product product)
        {
            var existproduct = GetProduct(product.Id);
            existproduct.Name = product.Name;
            return existproduct;
        }

        public Product GetProduct(Guid Id)
        {
            return products.SingleOrDefault(x => x.Id == Id);
        } 

        public List<Product> GetProducts()
        {
            return products;
        }
    }
}
