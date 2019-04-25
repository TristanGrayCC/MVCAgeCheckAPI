using DotNetCoreAPI.Dtos;
using DotNetCoreAPI.Models;

namespace DotNetCoreAPI.Services
{
    public static class ProductFactory
    {
        public static ProductDto CreateProductDto(Product product)
        {
            return new ProductDto
            {
                Name = product.Name,
                Description = product.Description,
                Category = product.Category.Name
            };
        }

        public static Product CreateProduct(ProductDto productDto, DALContext context)
        {
            var category = context.GetCategoryByName(productDto.Category);

            if (category == null)
            {
                category = new Category
                {
                    Name = productDto.Category
                };
            }

            return new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Category = category
            };
        }
    }
}
