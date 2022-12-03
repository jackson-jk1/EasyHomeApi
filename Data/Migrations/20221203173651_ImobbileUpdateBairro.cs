using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class ImobbileUpdateBairro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExternalId",
                table: "Immobile",
                newName: "externalId");

            migrationBuilder.AddColumn<int>(
                name: "bairroId",
                table: "Immobile",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Immobile_bairroId",
                table: "Immobile",
                column: "bairroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Immobile_Bairro_bairroId",
                table: "Immobile",
                column: "bairroId",
                principalTable: "Bairro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Immobile_Bairro_bairroId",
                table: "Immobile");

            migrationBuilder.DropIndex(
                name: "IX_Immobile_bairroId",
                table: "Immobile");

            migrationBuilder.DropColumn(
                name: "bairroId",
                table: "Immobile");

            migrationBuilder.RenameColumn(
                name: "externalId",
                table: "Immobile",
                newName: "ExternalId");
        }
    }
}
