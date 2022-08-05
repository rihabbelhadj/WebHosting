using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBHostingbackend.Migrations
{
    public partial class updatetest1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "id_service",
                table: "Commande",
                type: "int",
                nullable: false,
                defaultValue: false);
            migrationBuilder.AddColumn<bool>(
                name: "isValid",
                table: "Commande",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<float>(
                name: "prix",
                table: "Commande",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "tva",
                table: "Commande",
                type: "real",
                nullable: false,
                defaultValue: 0f); 
            migrationBuilder.AddColumn<int>(
                name: "nb_annee",
                table: "Commande",
                type: "int",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

           

           
        }
    }
}
