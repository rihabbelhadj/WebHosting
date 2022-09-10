using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBHostingbackend.Migrations
{
    public partial class addidCommandetotable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "id_commande",
                table: "Payement",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Payement_id_commande",
                table: "Payement",
                column: "id_commande");

            migrationBuilder.CreateIndex(
                name: "IX_Commande_id_commande",
                table: "Commande",
                column: "id_commande");

            migrationBuilder.AddForeignKey(
                name: "FK_Payement_Commande_id_commande",
                table: "Payement",
                column: "id_commande",
                principalTable: "Commande",
                principalColumn: "id_commande",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payement_Commande_id_commande",
                table: "Payement");

            migrationBuilder.DropIndex(
                name: "IX_Payement_id_commande",
                table: "Payement");

            migrationBuilder.DropIndex(
                name: "IX_Commande_id_commande",
                table: "Commande");

            migrationBuilder.DropColumn(
                name: "id_commande",
                table: "Payement");
        }
    }
}
