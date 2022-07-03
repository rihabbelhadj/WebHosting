using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBHostingbackend.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Domain",
                columns: table => new
                {
                    id_domain = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    domainName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    date_creation = table.Column<DateTime>(type: "date", nullable: true),
                    root = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    id_de_base = table.Column<int>(type: "int", nullable: true),
                    hebergement_type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domain", x => x.id_domain);
                });

            migrationBuilder.CreateTable(
                name: "Serveur",
                columns: table => new
                {
                    id_serveur = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    plateforme_type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    host_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    prix = table.Column<int>(type: "int", unicode: false, nullable: false),
                    nb_autorisé = table.Column<int>(type: "int", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serveur", x => x.id_serveur);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    id_service = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    service_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    espace_disque = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    trafic_mesuel = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    nb_email = table.Column<int>(type: "int", nullable: true),
                    type_hebergement = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    prix = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.id_service);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    idRole = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.idRole);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    idUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Nom = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Prenom = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Entreprise = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Etat = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Téléphone = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    idRole = table.Column<int>(type: "int", nullable: false),
                    password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.idUser);
                    table.ForeignKey(
                        name: "FK_User_UserRole",
                        column: x => x.idRole,
                        principalTable: "UserRole",
                        principalColumn: "idRole");
                });

            migrationBuilder.CreateTable(
                name: "Commande",
                columns: table => new
                {
                    id_commande = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_domaine = table.Column<int>(type: "int", nullable: false),
                    id_client = table.Column<int>(type: "int", nullable: false),
                    id_payement = table.Column<int>(type: "int", nullable: false),
                    etat = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    msg_erreur = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commande", x => x.id_commande);
                    table.ForeignKey(
                        name: "FK_Commande_domaine",
                        column: x => x.id_domaine,
                        principalTable: "Domain",
                        principalColumn: "id_domain");
                    table.ForeignKey(
                        name: "FK_Commande_User",
                        column: x => x.id_client,
                        principalTable: "Users",
                        principalColumn: "idUser");
                });

            migrationBuilder.CreateTable(
                name: "Payement",
                columns: table => new
                {
                    idPayement = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    date = table.Column<DateTime>(type: "date", nullable: true),
                    status = table.Column<int>(type: "int", nullable: true),
                    idUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payement", x => x.idPayement);
                    table.ForeignKey(
                        name: "FK_Payement_User",
                        column: x => x.idUser,
                        principalTable: "Users",
                        principalColumn: "idUser");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commande_id_client",
                table: "Commande",
                column: "id_client");

            migrationBuilder.CreateIndex(
                name: "IX_Commande_id_domaine",
                table: "Commande",
                column: "id_domaine");

            migrationBuilder.CreateIndex(
                name: "IX_Payement_idUser",
                table: "Payement",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_Users_idRole",
                table: "Users",
                column: "idRole");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commande");

            migrationBuilder.DropTable(
                name: "Payement");

            migrationBuilder.DropTable(
                name: "Serveur");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Domain");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserRole");
        }
    }
}
