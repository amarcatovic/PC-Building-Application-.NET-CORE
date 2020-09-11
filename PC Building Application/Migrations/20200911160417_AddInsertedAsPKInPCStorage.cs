using Microsoft.EntityFrameworkCore.Migrations;

namespace PC_Building_Application.Migrations
{
    public partial class AddInsertedAsPKInPCStorage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PCStorage",
                table: "PCStorage");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PCStorage",
                table: "PCStorage",
                columns: new[] { "StorageId", "PCId", "Inserted" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PCStorage",
                table: "PCStorage");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PCStorage",
                table: "PCStorage",
                columns: new[] { "StorageId", "PCId" });
        }
    }
}
