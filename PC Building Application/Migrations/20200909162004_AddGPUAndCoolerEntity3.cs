using Microsoft.EntityFrameworkCore.Migrations;

namespace PC_Building_Application.Migrations
{
    public partial class AddGPUAndCoolerEntity3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cooler_Manufacturers_ManufacturerId",
                table: "Cooler");

            migrationBuilder.DropForeignKey(
                name: "FK_Cooler_Photos_PhotoId",
                table: "Cooler");

            migrationBuilder.DropForeignKey(
                name: "FK_CoolerSocketType_Cooler_CoolerId",
                table: "CoolerSocketType");

            migrationBuilder.DropForeignKey(
                name: "FK_GPU_Manufacturers_ManufacturerId",
                table: "GPU");

            migrationBuilder.DropForeignKey(
                name: "FK_GPU_Photos_PhotoId",
                table: "GPU");

            migrationBuilder.DropForeignKey(
                name: "FK_PCs_Cooler_CoolerId",
                table: "PCs");

            migrationBuilder.DropForeignKey(
                name: "FK_PCs_GPU_GPUId",
                table: "PCs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GPU",
                table: "GPU");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cooler",
                table: "Cooler");

            migrationBuilder.RenameTable(
                name: "GPU",
                newName: "GPUs");

            migrationBuilder.RenameTable(
                name: "Cooler",
                newName: "Coolers");

            migrationBuilder.RenameIndex(
                name: "IX_GPU_PhotoId",
                table: "GPUs",
                newName: "IX_GPUs_PhotoId");

            migrationBuilder.RenameIndex(
                name: "IX_GPU_ManufacturerId",
                table: "GPUs",
                newName: "IX_GPUs_ManufacturerId");

            migrationBuilder.RenameIndex(
                name: "IX_Cooler_PhotoId",
                table: "Coolers",
                newName: "IX_Coolers_PhotoId");

            migrationBuilder.RenameIndex(
                name: "IX_Cooler_ManufacturerId",
                table: "Coolers",
                newName: "IX_Coolers_ManufacturerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GPUs",
                table: "GPUs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coolers",
                table: "Coolers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Coolers_Manufacturers_ManufacturerId",
                table: "Coolers",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Coolers_Photos_PhotoId",
                table: "Coolers",
                column: "PhotoId",
                principalTable: "Photos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoolerSocketType_Coolers_CoolerId",
                table: "CoolerSocketType",
                column: "CoolerId",
                principalTable: "Coolers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GPUs_Manufacturers_ManufacturerId",
                table: "GPUs",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GPUs_Photos_PhotoId",
                table: "GPUs",
                column: "PhotoId",
                principalTable: "Photos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PCs_Coolers_CoolerId",
                table: "PCs",
                column: "CoolerId",
                principalTable: "Coolers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PCs_GPUs_GPUId",
                table: "PCs",
                column: "GPUId",
                principalTable: "GPUs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coolers_Manufacturers_ManufacturerId",
                table: "Coolers");

            migrationBuilder.DropForeignKey(
                name: "FK_Coolers_Photos_PhotoId",
                table: "Coolers");

            migrationBuilder.DropForeignKey(
                name: "FK_CoolerSocketType_Coolers_CoolerId",
                table: "CoolerSocketType");

            migrationBuilder.DropForeignKey(
                name: "FK_GPUs_Manufacturers_ManufacturerId",
                table: "GPUs");

            migrationBuilder.DropForeignKey(
                name: "FK_GPUs_Photos_PhotoId",
                table: "GPUs");

            migrationBuilder.DropForeignKey(
                name: "FK_PCs_Coolers_CoolerId",
                table: "PCs");

            migrationBuilder.DropForeignKey(
                name: "FK_PCs_GPUs_GPUId",
                table: "PCs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GPUs",
                table: "GPUs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Coolers",
                table: "Coolers");

            migrationBuilder.RenameTable(
                name: "GPUs",
                newName: "GPU");

            migrationBuilder.RenameTable(
                name: "Coolers",
                newName: "Cooler");

            migrationBuilder.RenameIndex(
                name: "IX_GPUs_PhotoId",
                table: "GPU",
                newName: "IX_GPU_PhotoId");

            migrationBuilder.RenameIndex(
                name: "IX_GPUs_ManufacturerId",
                table: "GPU",
                newName: "IX_GPU_ManufacturerId");

            migrationBuilder.RenameIndex(
                name: "IX_Coolers_PhotoId",
                table: "Cooler",
                newName: "IX_Cooler_PhotoId");

            migrationBuilder.RenameIndex(
                name: "IX_Coolers_ManufacturerId",
                table: "Cooler",
                newName: "IX_Cooler_ManufacturerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GPU",
                table: "GPU",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cooler",
                table: "Cooler",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cooler_Manufacturers_ManufacturerId",
                table: "Cooler",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cooler_Photos_PhotoId",
                table: "Cooler",
                column: "PhotoId",
                principalTable: "Photos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoolerSocketType_Cooler_CoolerId",
                table: "CoolerSocketType",
                column: "CoolerId",
                principalTable: "Cooler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GPU_Manufacturers_ManufacturerId",
                table: "GPU",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GPU_Photos_PhotoId",
                table: "GPU",
                column: "PhotoId",
                principalTable: "Photos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PCs_Cooler_CoolerId",
                table: "PCs",
                column: "CoolerId",
                principalTable: "Cooler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PCs_GPU_GPUId",
                table: "PCs",
                column: "GPUId",
                principalTable: "GPU",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
