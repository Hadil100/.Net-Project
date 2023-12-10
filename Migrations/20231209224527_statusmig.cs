using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyNewProject.Migrations
{
    /// <inheritdoc />
    public partial class statusmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "Commands",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "Commands");

            migrationBuilder.AddColumn<int>(
                name: "CommandId",
                table: "ShoppingCardItems",
                type: "int",
                nullable: true);

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
    }
}
