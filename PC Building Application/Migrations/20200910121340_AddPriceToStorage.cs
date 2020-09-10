using Microsoft.EntityFrameworkCore.Migrations;

namespace PC_Building_Application.Migrations
{
    public partial class AddPriceToStorage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Storages",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Storages");
        }
    }
}
