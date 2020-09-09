using Microsoft.EntityFrameworkCore.Migrations;

namespace PC_Building_Application.Migrations
{
    public partial class AddManufacturerToRAM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ManufacturerId",
                table: "RAMs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RAMs_ManufacturerId",
                table: "RAMs",
                column: "ManufacturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_RAMs_Manufacturers_ManufacturerId",
                table: "RAMs",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RAMs_Manufacturers_ManufacturerId",
                table: "RAMs");

            migrationBuilder.DropIndex(
                name: "IX_RAMs_ManufacturerId",
                table: "RAMs");

            migrationBuilder.DropColumn(
                name: "ManufacturerId",
                table: "RAMs");
        }
    }
}
