using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WelfareSurveySystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class m13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealEstates_Employees_EmployeeID",
                table: "RealEstates");

            migrationBuilder.DropForeignKey(
                name: "FK_RealEstates_RealEstateTypes_RealEstateTypeId",
                table: "RealEstates");

            migrationBuilder.DropColumn(
                name: "DeceasedID",
                table: "RealEstates");

            migrationBuilder.AlterColumn<int>(
                name: "RealEstateTypeId",
                table: "RealEstates",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeID",
                table: "RealEstates",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstates_Employees_EmployeeID",
                table: "RealEstates",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstates_RealEstateTypes_RealEstateTypeId",
                table: "RealEstates",
                column: "RealEstateTypeId",
                principalTable: "RealEstateTypes",
                principalColumn: "RealEstateTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealEstates_Employees_EmployeeID",
                table: "RealEstates");

            migrationBuilder.DropForeignKey(
                name: "FK_RealEstates_RealEstateTypes_RealEstateTypeId",
                table: "RealEstates");

            migrationBuilder.AlterColumn<int>(
                name: "RealEstateTypeId",
                table: "RealEstates",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeID",
                table: "RealEstates",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DeceasedID",
                table: "RealEstates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstates_Employees_EmployeeID",
                table: "RealEstates",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstates_RealEstateTypes_RealEstateTypeId",
                table: "RealEstates",
                column: "RealEstateTypeId",
                principalTable: "RealEstateTypes",
                principalColumn: "RealEstateTypeId");
        }
    }
}
