using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBHostingbackend.Migrations
{
    public partial class updatetest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServIdService",
                table: "Commande",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Commande_ServIdService",
                table: "Commande",
                column: "ServIdService");

            migrationBuilder.AddForeignKey(
                name: "FK_Commande_Service_ServIdService",
                table: "Commande",
                column: "ServIdService",
                principalTable: "Service",
                principalColumn: "id_service",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commande_Service_ServIdService",
                table: "Commande");

            migrationBuilder.DropIndex(
                name: "IX_Commande_ServIdService",
                table: "Commande");

            migrationBuilder.DropColumn(
                name: "ServIdService",
                table: "Commande");
        }
    }
}
