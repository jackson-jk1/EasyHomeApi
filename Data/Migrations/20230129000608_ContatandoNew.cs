using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class ContatandoNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_User_ContactId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_User_UserId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_User_UsersThatContactMeId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_UsersThatContactMeId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "UsersThatContactMeId",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "ContactId",
                table: "Contacts",
                newName: "contactId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Contacts",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts_ContactId",
                table: "Contacts",
                newName: "IX_Contacts_contactId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_User_contactId",
                table: "Contacts",
                column: "contactId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_User_userId",
                table: "Contacts",
                column: "userId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_User_contactId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_User_userId",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "contactId",
                table: "Contacts",
                newName: "ContactId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Contacts",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts_contactId",
                table: "Contacts",
                newName: "IX_Contacts_ContactId");

            migrationBuilder.AddColumn<int>(
                name: "UsersThatContactMeId",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_UsersThatContactMeId",
                table: "Contacts",
                column: "UsersThatContactMeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_User_ContactId",
                table: "Contacts",
                column: "ContactId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_User_UserId",
                table: "Contacts",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_User_UsersThatContactMeId",
                table: "Contacts",
                column: "UsersThatContactMeId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
