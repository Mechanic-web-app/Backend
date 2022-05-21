using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MechanicWebAppAPI.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MessageReceiver",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Room_id",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ChatRooms",
                columns: table => new
                {
                    Room_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatRooms", x => x.Room_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_Room_id",
                table: "Messages",
                column: "Room_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_ChatRooms_Room_id",
                table: "Messages",
                column: "Room_id",
                principalTable: "ChatRooms",
                principalColumn: "Room_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_ChatRooms_Room_id",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "ChatRooms");

            migrationBuilder.DropIndex(
                name: "IX_Messages_Room_id",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "MessageReceiver",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "Room_id",
                table: "Messages");
        }
    }
}
