using DotNetCoreAPI.Models;
using DotNetCoreAPI.Services;
using Xunit;

namespace APITest.Services
{
    public class CategoryFactoryTests
    {
        [Fact]
        public void CreateCategoryDto_CreatesValidDto()
        {
            var name = "new category";

            var category = new Category
            {
                Name = name
            };

            var dto = CategoryFactory.CreateCategoryDto(category);

            Assert.NotNull(dto);
            Assert.Equal(name, dto.Name);
        }
    }
}
