using Microsoft.EntityFrameworkCore.Migrations;

namespace PC_Building_Application.Migrations
{
    public partial class AddInsertedAsPKInPCRam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PCRAM",
                table: "PCRAM");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PCRAM",
                table: "PCRAM",
                columns: new[] { "PCId", "RAMId", "Inserted" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PCRAM",
                table: "PCRAM");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PCRAM",
                table: "PCRAM",
                columns: new[] { "PCId", "RAMId" });
        }
    }
}
