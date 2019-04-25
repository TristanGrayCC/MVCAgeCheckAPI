using DotNetCoreAPI.Dtos;
using DotNetCoreAPI.Models;

namespace DotNetCoreAPI.Services
{
    public static class CategoryFactory
    {
        public static CategoryDto CreateCategoryDto(Category category)
        {
            return new CategoryDto
            {
                Name = category.Name
            };
        }
    }
}
