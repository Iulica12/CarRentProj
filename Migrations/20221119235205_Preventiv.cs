using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentProj.Migrations
{
    public partial class Preventiv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Make_MakeId",
                table: "Car");

            migrationBuilder.AlterColumn<int>(
                name: "MakeId",
                table: "Car",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Make_MakeId",
                table: "Car",
                column: "MakeId",
                principalTable: "Make",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Make_MakeId",
                table: "Car");

            migrationBuilder.AlterColumn<int>(
                name: "MakeId",
                table: "Car",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Make_MakeId",
                table: "Car",
                column: "MakeId",
                principalTable: "Make",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
