using DotNetCoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreAPI
{
    public class DALContext : DbContext
    {
        public DALContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Name = "Jaffa Clementines",
                Description = "12 easy peel clementines",
                Category = "Fruit"
            },

            new Product
            {
                Id = 2,
                Name = "Block Butter",
                Description = "Salted Block Butter 250G",
                Category = "Grocery"
            },

            new Product
            {
                Id = 3,
                Name = "Maris Potatoes",
                Description = "Maris Piper Potatoes 2.5Kg",
                Category = "Vegtable"
            },

            new Product
            {
                Id = 4,
                Name = "Lean Mice",
                Description = "Beef Lean Steak Mince 500G 5% Fat",
                Category = "Meat"
            },

            new Product
            {
                Id = 5,
                Name = "Jaffa Clementine",
                Description = "12 easy peel clementines",
                Category = "Fruit"
            },

            new Product
            {
                Id = 6,
                Name = "Strawberries",
                Description = "Fresh Strawberries 400G",
                Category = "Fruit"
            },

            new Product
            {
                Id = 7,
                Name = "Grapes",
                Description = "Red Seedless Grapes 500G",
                Category = "Fruit"
            },

            new Product
            {
                Id = 8,
                Name = "Chicken Breast",
                Description = "Chicken Breast Portions 650G",
                Category = "Meat"
            },

            new Product
            {
                Id = 9,
                Name = "Onions",
                Description = "Brown Onions Minimum 3 Pack 385G",
                Category = "Vegtable"
            },

            new Product
            {
                Id = 10,
                Name = "Bananas",
                Description = "Small Ripe Bananas 6 Pack",
                Category = "Fruit"
            });
        }
    }
}
