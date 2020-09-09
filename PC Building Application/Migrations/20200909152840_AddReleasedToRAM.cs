using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PC_Building_Application.Migrations
{
    public partial class AddReleasedToRAM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Released",
                table: "RAMs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Released",
                table: "RAMs");
        }
    }
}
