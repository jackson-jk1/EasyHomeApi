using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BairrosPolo",
                columns: table => new
                {
                    bairroId = table.Column<int>(type: "int", nullable: false),
                    poloId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BairrosPolo", x => new { x.poloId, x.bairroId });
                    table.ForeignKey(
                        name: "FK_BairrosPolo_Bairro_bairroId",
                        column: x => x.bairroId,
                        principalTable: "Bairro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BairrosPolo_Polo_poloId",
                        column: x => x.poloId,
                        principalTable: "Polo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");


            migrationBuilder.CreateIndex(
                name: "IX_BairrosPolo_bairroId",
                table: "BairrosPolo",
                column: "bairroId");

            migrationBuilder.CreateIndex(
                name: "IX_Immobile_bairroId",
                table: "Immobile",
                column: "bairroId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPreference_immobileId",
                table: "UserPreference",
                column: "immobileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BairrosPolo");

            migrationBuilder.DropTable(
                name: "UserPreference");

            migrationBuilder.DropTable(
                name: "Polo");

            migrationBuilder.DropTable(
                name: "Immobile");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Bairro");
        }
    }
}
