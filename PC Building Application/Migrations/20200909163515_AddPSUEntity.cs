using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PC_Building_Application.Migrations
{
    public partial class AddPSUEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PowerSupplyId",
                table: "PCs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PowerSupply",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Released = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Power = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoOfPCIe6Pins = table.Column<byte>(type: "tinyint", nullable: false),
                    NoOfPCIe8Pins = table.Column<byte>(type: "tinyint", nullable: false),
                    NoOfSATACables = table.Column<byte>(type: "tinyint", nullable: false),
                    NoOfCPUCables = table.Column<byte>(type: "tinyint", nullable: false),
                    Has24PinCable = table.Column<bool>(type: "bit", nullable: false),
                    EfficiencyRating = table.Column<byte>(type: "tinyint", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    PhotoId = table.Column<int>(type: "int", nullable: false),
                    ManufacturerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PowerSupply", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PowerSupply_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PowerSupply_Photos_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Photos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PCs_PowerSupplyId",
                table: "PCs",
                column: "PowerSupplyId");

            migrationBuilder.CreateIndex(
                name: "IX_PowerSupply_ManufacturerId",
                table: "PowerSupply",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_PowerSupply_PhotoId",
                table: "PowerSupply",
                column: "PhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_PCs_PowerSupply_PowerSupplyId",
                table: "PCs",
                column: "PowerSupplyId",
                principalTable: "PowerSupply",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PCs_PowerSupply_PowerSupplyId",
                table: "PCs");

            migrationBuilder.DropTable(
                name: "PowerSupply");

            migrationBuilder.DropIndex(
                name: "IX_PCs_PowerSupplyId",
                table: "PCs");

            migrationBuilder.DropColumn(
                name: "PowerSupplyId",
                table: "PCs");
        }
    }
}
