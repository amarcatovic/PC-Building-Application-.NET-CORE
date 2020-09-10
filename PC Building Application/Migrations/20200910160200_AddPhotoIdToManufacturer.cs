using Microsoft.EntityFrameworkCore.Migrations;

namespace PC_Building_Application.Migrations
{
    public partial class AddPhotoIdToManufacturer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PhotoId",
                table: "Manufacturers",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturers_PhotoId",
                table: "Manufacturers",
                column: "PhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Manufacturers_Photos_PhotoId",
                table: "Manufacturers",
                column: "PhotoId",
                principalTable: "Photos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Manufacturers_Photos_PhotoId",
                table: "Manufacturers");

            migrationBuilder.DropIndex(
                name: "IX_Manufacturers_PhotoId",
                table: "Manufacturers");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "Manufacturers");
        }
    }
}
