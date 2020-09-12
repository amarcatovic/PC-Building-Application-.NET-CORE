using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PC_Building_Application.Migrations
{
    public partial class AddJoinClassBetweenPCAndGPU : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PCs_GPUs_GPUId",
                table: "PCs");

            migrationBuilder.DropIndex(
                name: "IX_PCs_GPUId",
                table: "PCs");

            migrationBuilder.DropColumn(
                name: "GPUId",
                table: "PCs");

            migrationBuilder.CreateTable(
                name: "PCGPU",
                columns: table => new
                {
                    PCID = table.Column<int>(type: "int", nullable: false),
                    GPUId = table.Column<int>(type: "int", nullable: false),
                    Inserted = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PCGPU", x => new { x.GPUId, x.PCID, x.Inserted });
                    table.ForeignKey(
                        name: "FK_PCGPU_GPUs_GPUId",
                        column: x => x.GPUId,
                        principalTable: "GPUs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PCGPU_PCs_PCID",
                        column: x => x.PCID,
                        principalTable: "PCs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PCGPU_PCID",
                table: "PCGPU",
                column: "PCID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PCGPU");

            migrationBuilder.AddColumn<int>(
                name: "GPUId",
                table: "PCs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PCs_GPUId",
                table: "PCs",
                column: "GPUId");

            migrationBuilder.AddForeignKey(
                name: "FK_PCs_GPUs_GPUId",
                table: "PCs",
                column: "GPUId",
                principalTable: "GPUs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
