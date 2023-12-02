using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyNewProject.Migrations
{
    /// <inheritdoc />
    public partial class migration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategorieId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Commandes_CommandeId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Commandes");

            migrationBuilder.RenameColumn(
                name: "CommandeId",
                table: "Products",
                newName: "CommandId");

            migrationBuilder.RenameColumn(
                name: "CategorieId",
                table: "Products",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CommandeId",
                table: "Products",
                newName: "IX_Products_CommandId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategorieId",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.RenameColumn(
                name: "PrenomClient",
                table: "Clients",
                newName: "TelNumber");

            migrationBuilder.RenameColumn(
                name: "NumeroDeTel",
                table: "Clients",
                newName: "EmailAdress");

            migrationBuilder.RenameColumn(
                name: "NomClient",
                table: "Clients",
                newName: "ClientSecondName");

            migrationBuilder.RenameColumn(
                name: "AdresseEmail",
                table: "Clients",
                newName: "ClientFirstName");

            migrationBuilder.RenameColumn(
                name: "NomCategorie",
                table: "Categories",
                newName: "NameCategory");

            migrationBuilder.RenameColumn(
                name: "CategorieId",
                table: "Categories",
                newName: "CategoryId");

            migrationBuilder.CreateTable(
                name: "Commands",
                columns: table => new
                {
                    CommandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Total = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commands", x => x.CommandId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Commands_CommandId",
                table: "Products",
                column: "CommandId",
                principalTable: "Commands",
                principalColumn: "CommandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Commands_CommandId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Commands");

            migrationBuilder.RenameColumn(
                name: "CommandId",
                table: "Products",
                newName: "CommandeId");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Products",
                newName: "CategorieId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CommandId",
                table: "Products",
                newName: "IX_Products_CommandeId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                newName: "IX_Products_CategorieId");

            migrationBuilder.RenameColumn(
                name: "TelNumber",
                table: "Clients",
                newName: "PrenomClient");

            migrationBuilder.RenameColumn(
                name: "EmailAdress",
                table: "Clients",
                newName: "NumeroDeTel");

            migrationBuilder.RenameColumn(
                name: "ClientSecondName",
                table: "Clients",
                newName: "NomClient");

            migrationBuilder.RenameColumn(
                name: "ClientFirstName",
                table: "Clients",
                newName: "AdresseEmail");

            migrationBuilder.RenameColumn(
                name: "NameCategory",
                table: "Categories",
                newName: "NomCategorie");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Categories",
                newName: "CategorieId");

            migrationBuilder.CreateTable(
                name: "Commandes",
                columns: table => new
                {
                    CommandeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MontantTotal = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commandes", x => x.CommandeId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategorieId",
                table: "Products",
                column: "CategorieId",
                principalTable: "Categories",
                principalColumn: "CategorieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Commandes_CommandeId",
                table: "Products",
                column: "CommandeId",
                principalTable: "Commandes",
                principalColumn: "CommandeId");
        }
    }
}
