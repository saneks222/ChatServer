using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chat.Migrations
{
    public partial class contextModify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_UserId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInChat_AspNetUsers_UserId",
                table: "UserInChat");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInChat_Chats_ChatId",
                table: "UserInChat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserInChat",
                table: "UserInChat");

            migrationBuilder.RenameTable(
                name: "UserInChat",
                newName: "UserInChats");

            migrationBuilder.RenameIndex(
                name: "IX_UserInChat_UserId",
                table: "UserInChats",
                newName: "IX_UserInChats_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserInChat_ChatId",
                table: "UserInChats",
                newName: "IX_UserInChats_ChatId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserInChats",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserInChats",
                table: "UserInChats",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_UserId",
                table: "Messages",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInChats_AspNetUsers_UserId",
                table: "UserInChats",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInChats_Chats_ChatId",
                table: "UserInChats",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_UserId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInChats_AspNetUsers_UserId",
                table: "UserInChats");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInChats_Chats_ChatId",
                table: "UserInChats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserInChats",
                table: "UserInChats");

            migrationBuilder.RenameTable(
                name: "UserInChats",
                newName: "UserInChat");

            migrationBuilder.RenameIndex(
                name: "IX_UserInChats_UserId",
                table: "UserInChat",
                newName: "IX_UserInChat_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserInChats_ChatId",
                table: "UserInChat",
                newName: "IX_UserInChat_ChatId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserInChat",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserInChat",
                table: "UserInChat",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_UserId",
                table: "Messages",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInChat_AspNetUsers_UserId",
                table: "UserInChat",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInChat_Chats_ChatId",
                table: "UserInChat",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
