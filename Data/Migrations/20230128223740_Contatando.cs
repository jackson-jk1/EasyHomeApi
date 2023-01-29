using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Contatando : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContatandoId",
                table: "Notification",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_NotificationModel_ContatandoId",
                table: "Notification",
                column: "ContatandoId");

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationModel_User_ContatandoId",
                table: "Notification",
                column: "ContatandoId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotificationModel_User_ContatandoId",
                table: "Notification");

            migrationBuilder.DropIndex(
                name: "IX_NotificationModel_ContatandoId",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "ContatandoId",
                table: "Notification");
        }
    }
}
