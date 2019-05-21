using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCAgeCheck.Migrations
{
    public partial class AddingSuccessField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Successful",
                table: "Logins",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Successful",
                table: "Logins");
        }
    }
}
