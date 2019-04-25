using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetCoreAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Fruit", "12 easy peel clementines", "Jaffa Clementines" },
                    { 2, "Grocery", "Salted Block Butter 250G", "Block Butter" },
                    { 3, "Vegtable", "Maris Piper Potatoes 2.5Kg", "Maris Potatoes" },
                    { 4, "Meat", "Beef Lean Steak Mince 500G 5% Fat", "Lean Mice" },
                    { 5, "Fruit", "12 easy peel clementines", "Jaffa Clementine" },
                    { 6, "Fruit", "Fresh Strawberries 400G", "Strawberries" },
                    { 7, "Fruit", "Red Seedless Grapes 500G", "Grapes" },
                    { 8, "Meat", "Chicken Breast Portions 650G", "Chicken Breast" },
                    { 9, "Vegtable", "Brown Onions Minimum 3 Pack 385G", "Onions" },
                    { 10, "Fruit", "Small Ripe Bananas 6 Pack", "Bananas" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
