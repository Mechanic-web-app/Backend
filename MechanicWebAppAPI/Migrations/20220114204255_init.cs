using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MechanicWebAppAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User_confirmed = table.Column<bool>(type: "bit", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Token = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Car_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Car_brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Car_model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Car_reg_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Car_user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Car_id);
                    table.ForeignKey(
                        name: "FK_Cars_Users_Car_user_id",
                        column: x => x.Car_user_id,
                        principalTable: "Users",
                        principalColumn: "User_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Opinions",
                columns: table => new
                {
                    Opinion_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Opinion_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opinion_rate = table.Column<int>(type: "int", nullable: false),
                    Opinion_user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Opinion_user_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opinion_user_lastname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opinions", x => x.Opinion_id);
                    table.ForeignKey(
                        name: "FK_Opinions_Users_Opinion_user_id",
                        column: x => x.Opinion_user_id,
                        principalTable: "Users",
                        principalColumn: "User_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Repairs",
                columns: table => new
                {
                    Repair_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Repair_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Repair_cost = table.Column<float>(type: "real", nullable: false),
                    Repair_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Repaired_car_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repairs", x => x.Repair_id);
                    table.ForeignKey(
                        name: "FK_Repairs_Cars_Repaired_car_id",
                        column: x => x.Repaired_car_id,
                        principalTable: "Cars",
                        principalColumn: "Car_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_Car_user_id",
                table: "Cars",
                column: "Car_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Opinions_Opinion_user_id",
                table: "Opinions",
                column: "Opinion_user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_Repaired_car_id",
                table: "Repairs",
                column: "Repaired_car_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Opinions");

            migrationBuilder.DropTable(
                name: "Repairs");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
