using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyNewProject.Migrations
{
    /// <inheritdoc />
    public partial class ViewDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailsCommands_Products_ProductId",
                table: "DetailsCommands");

            migrationBuilder.DropIndex(
                name: "IX_DetailsCommands_ProductId",
                table: "DetailsCommands");
        }
    }
}
