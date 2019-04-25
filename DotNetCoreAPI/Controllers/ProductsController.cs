using System.Collections.Generic;
using DotNetCoreAPI.Dtos;
using DotNetCoreAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;
        public ProductsController(DALContext context)
        {
            _productService = new ProductService(context);
        }

        // GET api/products
        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> Get()
        {
            return _productService.GetAllProducts();
        }

        // GET api/products/categories
        [HttpGet("{category}")]
        public ActionResult<IEnumerable<ProductDto>> Get(string category)
        {
            return _productService.GetAllProductsByCategory(category);
        }

        // POST api/products
        [HttpPost]
        public void Post([FromBody] string name, string description, string category)
        {
            var newProduct = new ProductDto
            {
                Name = name,
                Description = description,
                Category = category
            };
            _productService.CreateProduct(newProduct);
        }

        // DELETE api/products/name
        [HttpDelete("{name}")]
        public void Delete(string name)
        {
            _productService.DeleteProduct(name);
        }
    }
}
