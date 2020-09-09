using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PC_Building_Application.Migrations
{
    public partial class AddGPUAndCoolerEntity2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CoolerId",
                table: "PCs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GPUId",
                table: "PCs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Cooler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Released = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsWaterCooler = table.Column<bool>(type: "bit", nullable: false),
                    HasRGB = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    PhotoId = table.Column<int>(type: "int", nullable: false),
                    ManufacturerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cooler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cooler_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cooler_Photos_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Photos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GPU",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Released = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PCIPort = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemoryType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VRAM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoOfHDMIPorts = table.Column<int>(type: "int", nullable: false),
                    NoOfDisplayPorts = table.Column<int>(type: "int", nullable: false),
                    HasVGA = table.Column<bool>(type: "bit", nullable: false),
                    HasDVI = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    PhotoId = table.Column<int>(type: "int", nullable: false),
                    ManufacturerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GPU", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GPU_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GPU_Photos_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Photos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoolerSocketType",
                columns: table => new
                {
                    CoolerId = table.Column<int>(type: "int", nullable: false),
                    SocketTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoolerSocketType", x => new { x.CoolerId, x.SocketTypeId });
                    table.ForeignKey(
                        name: "FK_CoolerSocketType_Cooler_CoolerId",
                        column: x => x.CoolerId,
                        principalTable: "Cooler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoolerSocketType_SocketTypes_SocketTypeId",
                        column: x => x.SocketTypeId,
                        principalTable: "SocketTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PCs_CoolerId",
                table: "PCs",
                column: "CoolerId");

            migrationBuilder.CreateIndex(
                name: "IX_PCs_GPUId",
                table: "PCs",
                column: "GPUId");

            migrationBuilder.CreateIndex(
                name: "IX_Cooler_ManufacturerId",
                table: "Cooler",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Cooler_PhotoId",
                table: "Cooler",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_CoolerSocketType_SocketTypeId",
                table: "CoolerSocketType",
                column: "SocketTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GPU_ManufacturerId",
                table: "GPU",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_GPU_PhotoId",
                table: "GPU",
                column: "PhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_PCs_Cooler_CoolerId",
                table: "PCs",
                column: "CoolerId",
                principalTable: "Cooler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PCs_GPU_GPUId",
                table: "PCs",
                column: "GPUId",
                principalTable: "GPU",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PCs_Cooler_CoolerId",
                table: "PCs");

            migrationBuilder.DropForeignKey(
                name: "FK_PCs_GPU_GPUId",
                table: "PCs");

            migrationBuilder.DropTable(
                name: "CoolerSocketType");

            migrationBuilder.DropTable(
                name: "GPU");

            migrationBuilder.DropTable(
                name: "Cooler");

            migrationBuilder.DropIndex(
                name: "IX_PCs_CoolerId",
                table: "PCs");

            migrationBuilder.DropIndex(
                name: "IX_PCs_GPUId",
                table: "PCs");

            migrationBuilder.DropColumn(
                name: "CoolerId",
                table: "PCs");

            migrationBuilder.DropColumn(
                name: "GPUId",
                table: "PCs");
        }
    }
}
