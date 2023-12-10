using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyNewProject.Migrations
{
    /// <inheritdoc />
    public partial class DetailsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NomberLike",
                table: "Favorites",
                newName: "NumberLike");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Commands",
                newName: "UserId");

            migrationBuilder.CreateTable(
                name: "DetailsCommands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommandId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailsCommands", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailsCommands");

            migrationBuilder.RenameColumn(
                name: "NumberLike",
                table: "Favorites",
                newName: "NomberLike");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Commands",
                newName: "UserName");
        }
    }
}
