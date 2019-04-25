using DotNetCoreAPI.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace DotNetCoreAPI.Services
{
    public class ProductService
    {
        private readonly DALContext _dalContext;
        private const string success = "Success";
        private const string failure = "Failed";

        public ProductService(DALContext context)
        {
            _dalContext = context;
        }

        public string DeleteProduct(string name)
        {
            var product = _dalContext.GetProducts.Single(x => x.Name == name);
            try
            {
                _dalContext.RemoveProduct(product);
                _dalContext.SaveChanges();
                return success;
            }
            catch
            {
                return failure;
            }
        }

        public string CreateProduct(ProductDto productDto)
        {
            var product = ProductFactory.CreateProduct(productDto, _dalContext);

            try
            {
                _dalContext.AddProduct(product);
                _dalContext.SaveChanges();
                return success;
            }
            catch
            {
                return failure;
            }
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            return _dalContext.GetProducts.Select(x => ProductFactory.CreateProductDto(x));
        }

        public IEnumerable<ProductDto> GetAllProductsByCategory(string category)
        {
            return _dalContext.GetProducts.Where(x => x.Category.Name == category).Select(x => ProductFactory.CreateProductDto(x));
        }

        public IEnumerable<CategoryDto> GetAllCategories()
        {
            return _dalContext.GetCategories.Select(x => CategoryFactory.CreateCategoryDto(x));
        }
    }
}
