using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class DALContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Name = "Jaffa Clementine",
                Description = "12 easy peel clementines",
                Category = "Fruit"
            },
                new Product
                {
                    Name = "Jaffa Clementine",
                    Description = "12 easy peel clementines",
                    Category = "Fruit"
                },
                new Product
                {
                    Name = "Jaffa Clementine",
                    Description = "12 easy peel clementines",
                    Category = "Fruit"
                },
                new Product
                {
                    Name = "Jaffa Clementine",
                    Description = "12 easy peel clementines",
                    Category = "Fruit"
                },
                new Product
                {
                    Name = "Jaffa Clementine",
                    Description = "12 easy peel clementines",
                    Category = "Fruit"
                },
                new Product
                {
                    Name = "Jaffa Clementine",
                    Description = "12 easy peel clementines",
                    Category = "Fruit"
                },
                new Product
                {
                    Name = "Jaffa Clementine",
                    Description = "12 easy peel clementines",
                    Category = "Fruit"
                },
                new Product
                {
                    Name = "Jaffa Clementine",
                    Description = "12 easy peel clementines",
                    Category = "Fruit"
                },
                new Product
                {
                    Name = "Jaffa Clementine",
                    Description = "12 easy peel clementines",
                    Category = "Fruit"
                },
                new Product
                {
                    Name = "Jaffa Clementine",
                    Description = "12 easy peel clementines",
                    Category = "Fruit"
                }
                );
        }
    }
}
