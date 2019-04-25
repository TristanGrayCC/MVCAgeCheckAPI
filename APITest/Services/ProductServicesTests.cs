using DotNetCoreAPI;
using DotNetCoreAPI.Dtos;
using DotNetCoreAPI.Models;
using DotNetCoreAPI.Services;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace APITest.Services
{
    public class ProductServicesTests
    {
        private readonly ProductService _underTest;
        private readonly Mock<DALContext> _context;

        public ProductServicesTests()
        {
            _context = new Mock<DALContext>();
            _underTest = new ProductService(_context.Object);
        }

        [Fact]
        public void GetAllProductsByCategory_ReturnsOnlyInCorrectCategoryAsDtos()
        {
            var name = "new product";
            var categoryToSearch = "Fruit";
            var listOfFruits = new List<string>
            {
                "Strawberries", "Bananas", "Oranges"
            };
            var listOfNotFruits = new List<string>
            {
                "Bear", "Window"
            };

            var categorySearched = new Category
            {
                Name = categoryToSearch
            };

            var notCategorySearched = new Category
            {
                Name = "Not this"
            };

            var allProducts = new List<Product>();

            foreach(var fruit in listOfFruits)
            {
                allProducts.Add(new Product
                {
                    Name = fruit,
                    Description = fruit,
                    Category = categorySearched
                });
            }

            foreach (var notFruit in listOfNotFruits)
            {
                allProducts.Add(new Product
                {
                    Name = notFruit,
                    Description = notFruit,
                    Category = notCategorySearched
                });
            }

            _context.Setup(x => x.GetProducts).Returns(allProducts.AsQueryable());

            var result = _underTest.GetAllProductsByCategory(categoryToSearch);

            Assert.NotNull(result);
            Assert.Equal(listOfFruits.Count, result.Count);

            foreach (var fruit in listOfFruits)
            {
                Assert.Contains(fruit, result.Select(x => x.Name));
                var fruitFound = result.Single(x => x.Name == fruit);
                Assert.Equal(typeof(ProductDto), fruitFound.GetType());
                Assert.Equal(categoryToSearch, fruitFound.Category);
            }

            foreach (var notAFruit in listOfNotFruits)
            {
                Assert.DoesNotContain(notAFruit, result.Select(x => x.Name));
            }
        }
    }
}
