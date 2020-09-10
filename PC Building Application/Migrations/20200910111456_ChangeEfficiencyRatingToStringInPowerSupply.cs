using Microsoft.EntityFrameworkCore.Migrations;

namespace PC_Building_Application.Migrations
{
    public partial class ChangeEfficiencyRatingToStringInPowerSupply : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EfficiencyRating",
                table: "PowerSupplies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "EfficiencyRating",
                table: "PowerSupplies",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
