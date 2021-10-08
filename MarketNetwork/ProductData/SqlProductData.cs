using MarketNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketNetwork.ProductData
{
    public class SqlProductData : IProductData
    {

        private ProductContext _productContext;

        public SqlProductData(ProductContext productContext)
        {
            _productContext = productContext;
        }
        public Product AddProduct(Product product)
        {
            product.Id = Guid.NewGuid();
            _productContext.Products.Add(product);
            _productContext.SaveChanges();
            return product;
        }

        public void DeleteProduct(Product product)
        {
            _productContext.Products.Remove(product);
        }

        public Product EditProduct(Product product)
        {
            var existproduct = _productContext.Products.Find(product.Id);
            if (existproduct != null)
            {
                existproduct.Name = product.Name;
                _productContext.Products.Update(existproduct);
                _productContext.SaveChanges();

            }

            return product;
        }

        public Product GetProduct(Guid Id)
        {
            var product = _productContext.Products.Find(Id);
            return product;
        }

        public List<Product> GetProducts()
        {
            return _productContext.Products.ToList();
        }
    }
}
