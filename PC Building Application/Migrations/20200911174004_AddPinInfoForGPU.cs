using Microsoft.EntityFrameworkCore.Migrations;

namespace PC_Building_Application.Migrations
{
    public partial class AddPinInfoForGPU : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "NoOfPCIe12Pins",
                table: "GPUs",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "NoOfPCIe6Pins",
                table: "GPUs",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "NoOfPCIe8Pins",
                table: "GPUs",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoOfPCIe12Pins",
                table: "GPUs");

            migrationBuilder.DropColumn(
                name: "NoOfPCIe6Pins",
                table: "GPUs");

            migrationBuilder.DropColumn(
                name: "NoOfPCIe8Pins",
                table: "GPUs");
        }
    }
}
