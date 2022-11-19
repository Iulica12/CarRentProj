using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentProj.Migrations
{
    public partial class AddedValidationRules1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Car",
                newName: "Model");

            migrationBuilder.AddColumn<int>(
                name: "MakeId",
                table: "Car",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Make",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MakeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Make", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_MakeId",
                table: "Car",
                column: "MakeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Make_MakeId",
                table: "Car",
                column: "MakeId",
                principalTable: "Make",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Make_MakeId",
                table: "Car");

            migrationBuilder.DropTable(
                name: "Make");

            migrationBuilder.DropIndex(
                name: "IX_Car_MakeId",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "MakeId",
                table: "Car");

            migrationBuilder.RenameColumn(
                name: "Model",
                table: "Car",
                newName: "Name");
        }
    }
}
