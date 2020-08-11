using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PC_Building_Application.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocketTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocketTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CPUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Released = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SocketTypeId = table.Column<int>(type: "int", nullable: false),
                    Clockspeed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TurboSpeed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoOfCores = table.Column<int>(type: "int", nullable: false),
                    SingleThreadRating = table.Column<int>(type: "int", nullable: false),
                    ManufacturerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPUs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CPUs_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CPUs_SocketTypes_SocketTypeId",
                        column: x => x.SocketTypeId,
                        principalTable: "SocketTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Motherboards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Released = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SocketTypeId = table.Column<int>(type: "int", nullable: false),
                    MaxMemmoryFreq = table.Column<int>(type: "int", nullable: false),
                    MemoryType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoOfM2Slots = table.Column<int>(type: "int", nullable: false),
                    HasRGB = table.Column<bool>(type: "bit", nullable: false),
                    NoOfPCIeSlots = table.Column<int>(type: "int", nullable: false),
                    NoOfRAMSlots = table.Column<int>(type: "int", nullable: false),
                    ManufacturerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motherboards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Motherboards_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Motherboards_SocketTypes_SocketTypeId",
                        column: x => x.SocketTypeId,
                        principalTable: "SocketTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CPUs_ManufacturerId",
                table: "CPUs",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_CPUs_Name",
                table: "CPUs",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_CPUs_SocketTypeId",
                table: "CPUs",
                column: "SocketTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturers_Name",
                table: "Manufacturers",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_ManufacturerId",
                table: "Motherboards",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_Name_Released",
                table: "Motherboards",
                columns: new[] { "Name", "Released" });

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_SocketTypeId",
                table: "Motherboards",
                column: "SocketTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SocketTypes_Name",
                table: "SocketTypes",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName_Email",
                table: "Users",
                columns: new[] { "UserName", "Email" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CPUs");

            migrationBuilder.DropTable(
                name: "Motherboards");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropTable(
                name: "SocketTypes");
        }
    }
}
