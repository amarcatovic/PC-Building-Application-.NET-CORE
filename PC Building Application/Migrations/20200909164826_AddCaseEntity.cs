using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PC_Building_Application.Migrations
{
    public partial class AddCaseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PCs_PowerSupply_PowerSupplyId",
                table: "PCs");

            migrationBuilder.DropForeignKey(
                name: "FK_PowerSupply_Manufacturers_ManufacturerId",
                table: "PowerSupply");

            migrationBuilder.DropForeignKey(
                name: "FK_PowerSupply_Photos_PhotoId",
                table: "PowerSupply");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PowerSupply",
                table: "PowerSupply");

            migrationBuilder.RenameTable(
                name: "PowerSupply",
                newName: "PowerSupplies");

            migrationBuilder.RenameIndex(
                name: "IX_PowerSupply_PhotoId",
                table: "PowerSupplies",
                newName: "IX_PowerSupplies_PhotoId");

            migrationBuilder.RenameIndex(
                name: "IX_PowerSupply_ManufacturerId",
                table: "PowerSupplies",
                newName: "IX_PowerSupplies_ManufacturerId");

            migrationBuilder.AddColumn<int>(
                name: "CaseId",
                table: "PCs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Power",
                table: "PowerSupplies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PowerSupplies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PowerSupplies",
                table: "PowerSupplies",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Released = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoOfUSB3Ports = table.Column<byte>(type: "tinyint", nullable: false),
                    HasRGB = table.Column<bool>(type: "bit", nullable: false),
                    HasScreen = table.Column<bool>(type: "bit", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    PhotoId = table.Column<int>(type: "int", nullable: false),
                    ManufacturerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cases_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cases_Photos_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Photos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PCs_CaseId",
                table: "PCs",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_ManufacturerId",
                table: "Cases",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_PhotoId",
                table: "Cases",
                column: "PhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_PCs_Cases_CaseId",
                table: "PCs",
                column: "CaseId",
                principalTable: "Cases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PCs_PowerSupplies_PowerSupplyId",
                table: "PCs",
                column: "PowerSupplyId",
                principalTable: "PowerSupplies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PowerSupplies_Manufacturers_ManufacturerId",
                table: "PowerSupplies",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PowerSupplies_Photos_PhotoId",
                table: "PowerSupplies",
                column: "PhotoId",
                principalTable: "Photos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PCs_Cases_CaseId",
                table: "PCs");

            migrationBuilder.DropForeignKey(
                name: "FK_PCs_PowerSupplies_PowerSupplyId",
                table: "PCs");

            migrationBuilder.DropForeignKey(
                name: "FK_PowerSupplies_Manufacturers_ManufacturerId",
                table: "PowerSupplies");

            migrationBuilder.DropForeignKey(
                name: "FK_PowerSupplies_Photos_PhotoId",
                table: "PowerSupplies");

            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropIndex(
                name: "IX_PCs_CaseId",
                table: "PCs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PowerSupplies",
                table: "PowerSupplies");

            migrationBuilder.DropColumn(
                name: "CaseId",
                table: "PCs");

            migrationBuilder.RenameTable(
                name: "PowerSupplies",
                newName: "PowerSupply");

            migrationBuilder.RenameIndex(
                name: "IX_PowerSupplies_PhotoId",
                table: "PowerSupply",
                newName: "IX_PowerSupply_PhotoId");

            migrationBuilder.RenameIndex(
                name: "IX_PowerSupplies_ManufacturerId",
                table: "PowerSupply",
                newName: "IX_PowerSupply_ManufacturerId");

            migrationBuilder.AlterColumn<string>(
                name: "Power",
                table: "PowerSupply",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PowerSupply",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PowerSupply",
                table: "PowerSupply",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PCs_PowerSupply_PowerSupplyId",
                table: "PCs",
                column: "PowerSupplyId",
                principalTable: "PowerSupply",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PowerSupply_Manufacturers_ManufacturerId",
                table: "PowerSupply",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PowerSupply_Photos_PhotoId",
                table: "PowerSupply",
                column: "PhotoId",
                principalTable: "Photos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
