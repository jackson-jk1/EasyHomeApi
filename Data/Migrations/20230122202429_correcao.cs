using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class correcao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AlternateKey_CellPhone",
                table: "User");

            migrationBuilder.DropUniqueConstraint(
                name: "AlternateKey_Email",
                table: "User");

            migrationBuilder.CreateIndex(
                name: "IX_User_CellPhone",
                table: "User",
                column: "CellPhone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_CellPhone",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_Email",
                table: "User");

            migrationBuilder.AddUniqueConstraint(
                name: "AlternateKey_CellPhone",
                table: "User",
                column: "CellPhone");

            migrationBuilder.AddUniqueConstraint(
                name: "AlternateKey_Email",
                table: "User",
                column: "Email");
        }
    }
}
