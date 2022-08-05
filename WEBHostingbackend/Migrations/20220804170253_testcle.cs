using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBHostingbackend.Migrations
{
    public partial class testcle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Commande_id_domaine",
                table: "Commande",
                column: "id_domaine");

            migrationBuilder.AddForeignKey(
                name: "FK_Commande_Domain_id_domaine",
                table: "Commande",
                column: "id_domaine",
                principalTable: "Domain",
                principalColumn: "id_domain",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commande_Domain_id_domaine",
                table: "Commande");

            migrationBuilder.DropIndex(
                name: "IX_Commande_id_domaine",
                table: "Commande");
        }
    }
}
