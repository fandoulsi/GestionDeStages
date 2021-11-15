using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionDesStagePS.Server.Migrations
{
    public partial class AjoutTablePostulerStage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Etudiant",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TelephoneCellulaire = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etudiant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostulerStage",
                columns: table => new
                {
                    PostulerStageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    DatePostule = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostulerStage", x => x.PostulerStageId);
                    table.ForeignKey(
                        name: "FK_PostulerStage_Etudiant_Id",
                        column: x => x.Id,
                        principalTable: "Etudiant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostulerStage_Stage_StageId",
                        column: x => x.StageId,
                        principalTable: "Stage",
                        principalColumn: "StageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostulerStage_Id",
                table: "PostulerStage",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PostulerStage_StageId",
                table: "PostulerStage",
                column: "StageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostulerStage");

            migrationBuilder.DropTable(
                name: "Etudiant");
        }
    }
}
