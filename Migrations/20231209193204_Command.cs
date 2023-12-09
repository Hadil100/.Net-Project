using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyNewProject.Migrations
{
    /// <inheritdoc />
    public partial class Command : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Commands_CommandId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CommandId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CommandId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "CommandId",
                table: "ShoppingCardItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Commands",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCardItems_CommandId",
                table: "ShoppingCardItems",
                column: "CommandId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCardItems_Commands_CommandId",
                table: "ShoppingCardItems",
                column: "CommandId",
                principalTable: "Commands",
                principalColumn: "CommandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCardItems_Commands_CommandId",
                table: "ShoppingCardItems");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCardItems_CommandId",
                table: "ShoppingCardItems");

            migrationBuilder.DropColumn(
                name: "CommandId",
                table: "ShoppingCardItems");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Commands");

            migrationBuilder.AddColumn<int>(
                name: "CommandId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CommandId",
                table: "Products",
                column: "CommandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Commands_CommandId",
                table: "Products",
                column: "CommandId",
                principalTable: "Commands",
                principalColumn: "CommandId");
        }
    }
}
