using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionDesStagePS.Server.Migrations
{
    public partial class AjoutTableCoordonnateur : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coordonnateur",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TelephoneCellulaire = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    NomInstitution = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Remarques = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordonnateur", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coordonnateur");
        }
    }
}
