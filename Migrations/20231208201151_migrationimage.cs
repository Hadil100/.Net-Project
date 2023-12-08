using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyNewProject.Migrations
{
    /// <inheritdoc />
    public partial class migrationimage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductPath",
                table: "ShoppingCardItems",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductPath",
                table: "ShoppingCardItems");
        }
    }
}
