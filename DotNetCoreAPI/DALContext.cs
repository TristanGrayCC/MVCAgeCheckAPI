using DotNetCoreAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DotNetCoreAPI
{
    public class DALContext : DbContext
    {
        public DALContext() { }

        public DALContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public virtual IQueryable<Product> GetProducts => Products.Include(x => x.Category);

        public IQueryable<Category> GetCategories=> Categories;

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            Products.Remove(product);
        }

        public virtual Category GetCategoryByName(string name)
        {
            return Categories.SingleOrDefault(x => x.Name == name);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = 1,
                Name = "Fruit"
            },
            new Category
            {
                Id = 2,
                Name = "Grocery"
            },
            new Category
            {
                Id = 3,
                Name = "Vegetable"
            },
            new Category
            {
                Id = 4,
                Name = "Meat"
            }
            );

            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Name = "Jaffa Clementines",
                Description = "12 easy peel clementines",
                CategoryId = 1
            },

            new Product
            {
                Id = 2,
                Name = "Block Butter",
                Description = "Salted Block Butter 250G",
                CategoryId = 2
            },

            new Product
            {
                Id = 3,
                Name = "Maris Potatoes",
                Description = "Maris Piper Potatoes 2.5Kg",
                CategoryId = 3
            },

            new Product
            {
                Id = 4,
                Name = "Lean Mice",
                Description = "Beef Lean Steak Mince 500G 5% Fat",
                CategoryId = 4
            },

            new Product
            {
                Id = 5,
                Name = "Jaffa Clementine",
                Description = "12 easy peel clementines",
                CategoryId = 1
            },

            new Product
            {
                Id = 6,
                Name = "Strawberries",
                Description = "Fresh Strawberries 400G",
                CategoryId = 1
            },

            new Product
            {
                Id = 7,
                Name = "Grapes",
                Description = "Red Seedless Grapes 500G",
                CategoryId = 1
            },

            new Product
            {
                Id = 8,
                Name = "Chicken Breast",
                Description = "Chicken Breast Portions 650G",
                CategoryId = 4
            },

            new Product
            {
                Id = 9,
                Name = "Onions",
                Description = "Brown Onions Minimum 3 Pack 385G",
                CategoryId = 3
            },

            new Product
            {
                Id = 10,
                Name = "Bananas",
                Description = "Small Ripe Bananas 6 Pack",
                CategoryId = 1
            });
        }
    }
}
