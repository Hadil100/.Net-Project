using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyNewProject.Migrations
{
    /// <inheritdoc />
    public partial class detailsMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailsCommands_Products_ProductId",
                table: "DetailsCommands");

            migrationBuilder.DropIndex(
                name: "IX_DetailsCommands_ProductId",
                table: "DetailsCommands");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "DetailsCommands");

            migrationBuilder.AddColumn<int>(
                name: "Product",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_Product",
                table: "Products",
                column: "Product");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_DetailsCommands_Product",
                table: "Products",
                column: "Product",
                principalTable: "DetailsCommands",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_DetailsCommands_Product",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_Product",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Product",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "DetailsCommands",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DetailsCommands_ProductId",
                table: "DetailsCommands",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailsCommands_Products_ProductId",
                table: "DetailsCommands",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
