using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBHostingbackend.Migrations
{
    public partial class service : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commande_domaine",
                table: "Commande");

            migrationBuilder.DropIndex(
                name: "IX_Commande_id_client",
                table: "Commande");

            migrationBuilder.DropIndex(
                name: "IX_Commande_id_domaine",
                table: "Commande");

            migrationBuilder.AddColumn<string>(
                name: "bande_passante",
                table: "Service",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bande_passante",
                table: "Service");

            migrationBuilder.CreateIndex(
                name: "IX_Commande_id_client",
                table: "Commande",
                column: "id_client");

            migrationBuilder.CreateIndex(
                name: "IX_Commande_id_domaine",
                table: "Commande",
                column: "id_domaine");

            migrationBuilder.AddForeignKey(
                name: "FK_Commande_domaine",
                table: "Commande",
                column: "id_domaine",
                principalTable: "Domain",
                principalColumn: "id_domain");
        }
    }
}
