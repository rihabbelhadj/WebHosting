using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBHostingbackend.Migrations
{
    public partial class testtt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "id_user",
                table: "Commande");

            migrationBuilder.CreateIndex(
                name: "IX_Commande_id_service",
                table: "Commande",
                column: "id_service");

            migrationBuilder.AddForeignKey(
                name: "FK_Commande_Service_id_service",
                table: "Commande",
                column: "id_service",
                principalTable: "Service",
                principalColumn: "id_service",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commande_Service_id_service",
                table: "Commande");

            migrationBuilder.DropIndex(
                name: "IX_Commande_id_service",
                table: "Commande");

            migrationBuilder.AddColumn<int>(
                name: "ServIdService",
                table: "Commande",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "id_user",
                table: "Commande",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
    }
}
