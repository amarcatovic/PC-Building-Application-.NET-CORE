using Microsoft.EntityFrameworkCore.Migrations;

namespace PC_Building_Application.Migrations
{
    public partial class AddPhotoToCPUEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PhotoId",
                table: "CPUs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CPUs_PhotoId",
                table: "CPUs",
                column: "PhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_CPUs_Photos_PhotoId",
                table: "CPUs",
                column: "PhotoId",
                principalTable: "Photos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CPUs_Photos_PhotoId",
                table: "CPUs");

            migrationBuilder.DropIndex(
                name: "IX_CPUs_PhotoId",
                table: "CPUs");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "CPUs");
        }
    }
}
