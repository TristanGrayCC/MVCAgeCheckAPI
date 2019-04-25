using DotNetCoreAPI;
using DotNetCoreAPI.Dtos;
using DotNetCoreAPI.Models;
using DotNetCoreAPI.Services;
using Moq;
using Xunit;

namespace APITest.Services
{
    public class ProductFactoryTests
    {
        [Fact]
        public void CreateProductDto_CreatesValidDto()
        {
            var name = "new product";
            var categoryName = "category";
            var category = new Category
            {
                Name = categoryName
            };
            var description = "this is a brand new product";

            var product = new Product
            {
                Name = name,
                Description = description,
                Category = category
            };

            var dto = ProductFactory.CreateProductDto(product);

            Assert.NotNull(dto);
            Assert.Equal(name, dto.Name);
            Assert.Equal(description, dto.Description);
            Assert.Equal(categoryName, dto.Category);
        }

        [Fact]
        public void CreateProduct_CreatesValidModel()
        {
            var name = "new product";
            var categoryName = "category";
            var category = new Category
            {
                Name = categoryName
            };
            var description = "this is a brand new product";

            var product = new ProductDto
            {
                Name = name,
                Description = description,
                Category = categoryName
            };

            var mockContext = new Mock<DALContext>();
            mockContext.Setup(x => x.GetCategoryByName(categoryName)).Returns(category);

            var model = ProductFactory.CreateProduct(product, mockContext.Object);

            Assert.NotNull(model);
            Assert.Equal(name, model.Name);
            Assert.Equal(description, model.Description);
            Assert.Equal(categoryName, model.Category.Name);
        }

        [Fact]
        public void CreateProduct_WhenNoCurrentCategory_CreatesValidModel()
        {
            var name = "new product";
            var categoryName = "category";
            var category = new Category
            {
                Name = categoryName
            };
            var description = "this is a brand new product";

            var product = new ProductDto
            {
                Name = name,
                Description = description,
                Category = categoryName
            };

            var mockContext = new Mock<DALContext>();
            mockContext.Setup(x => x.GetCategoryByName(categoryName)).Returns((Category)null);

            var model = ProductFactory.CreateProduct(product, mockContext.Object);

            Assert.NotNull(model);
            Assert.Equal(name, model.Name);
            Assert.Equal(description, model.Description);
            Assert.Equal(categoryName, model.Category.Name);
        }
    }
}
