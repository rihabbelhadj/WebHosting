using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBHostingbackend.Migrations
{
    public partial class addrelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

           
           
            migrationBuilder.AlterColumn<Guid>(
                name: "id_de_base",
                table: "Domain",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

           

            migrationBuilder.CreateIndex(
                name: "IX_Domain_id_de_base",
                table: "Domain",
                column: "id_de_base");

            migrationBuilder.AddForeignKey(
                name: "FK_Domain_AspNetUsers_id_de_base",
                table: "Domain",
                column: "id_de_base",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Domain_AspNetUsers_id_de_base",
                table: "Domain");

            migrationBuilder.DropForeignKey(
                name: "FK_Payement_AspNetUsers_idUser",
                table: "Payement");

            migrationBuilder.DropIndex(
                name: "IX_Payement_idUser",
                table: "Payement");

            migrationBuilder.DropIndex(
                name: "IX_Domain_id_de_base",
                table: "Domain");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Payement",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<int>(
                name: "id_de_base",
                table: "Domain",
                type: "int",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payement_UserId",
                table: "Payement",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payement_AspNetUsers_UserId",
                table: "Payement",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
