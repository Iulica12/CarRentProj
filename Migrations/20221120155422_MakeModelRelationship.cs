using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentProj.Migrations
{
    public partial class MakeModelRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MakeId",
                table: "CarModels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_MakeId",
                table: "CarModels",
                column: "MakeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarModels_Make_MakeId",
                table: "CarModels",
                column: "MakeId",
                principalTable: "Make",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarModels_Make_MakeId",
                table: "CarModels");

            migrationBuilder.DropIndex(
                name: "IX_CarModels_MakeId",
                table: "CarModels");

            migrationBuilder.DropColumn(
                name: "MakeId",
                table: "CarModels");
        }
    }
}
