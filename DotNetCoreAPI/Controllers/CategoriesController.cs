using System.Collections.Generic;
using DotNetCoreAPI.Dtos;
using DotNetCoreAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ProductService _productService;
        public CategoriesController(DALContext context)
        {
            _productService = new ProductService(context);
        }

        // GET api/categories
        [HttpGet]
        public ActionResult<IEnumerable<CategoryDto>> Get()
        {
            return _productService.GetAllCategories();
        }
    }
}
