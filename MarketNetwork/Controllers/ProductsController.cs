using Microsoft.AspNetCore.Mvc;
using MarketNetwork.ProductData;
using System;
using MarketNetwork.Models;

namespace MarketNetwork.Controllers
{
   
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductData _productData;

        public ProductsController(IProductData productData)
        {
            _productData = productData;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetProducts()
        {
            return Ok(_productData.GetProducts());      
        }


        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetProduct(Guid Id)
        {
            var product = _productData.GetProduct(Id);

            if (product != null)
            {
                return Ok(product);
            }

            return NotFound($"Product with Id: {Id} was not found");
           
        }


        [HttpPost]
        [Route("api/[controller]")]
        //[Consumes("application/json")]
        public IActionResult GetProduct(Product product)
        {
            _productData.AddProduct(product);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + product.Id,product);

        }


        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteProduct(Guid Id)
        {
            var product = _productData.GetProduct(Id);

            if (product != null)
            {
               _productData.DeleteProduct(product);
                return Ok();
            }

            return NotFound($"Product with Id: {Id} was not found");

        }


        [HttpPatch]
        [Route("api/[controller]/{id}")]
        [Consumes("application/json")]
        public IActionResult EditProduct(Guid Id,Product product)
        {

            var existproduct = _productData.GetProduct(Id);
            if (existproduct != null)
            {
                product.Id = existproduct.Id;
                _productData.EditProduct(product);

            }

            return Ok(product);
        }

    }
}
