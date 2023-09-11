using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WelfareSurveySystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeceasedForms_Employees_EmployeeID",
                table: "DeceasedForms");

            migrationBuilder.DropForeignKey(
                name: "FK_DeceasedForms_Employees_EmployeeID2",
                table: "DeceasedForms");

            migrationBuilder.DropIndex(
                name: "IX_DeceasedForms_EmployeeID2",
                table: "DeceasedForms");

            migrationBuilder.DropColumn(
                name: "EmployeeID2",
                table: "DeceasedForms");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeID",
                table: "DeceasedForms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_DeceasedForms_Employees_EmployeeID",
                table: "DeceasedForms",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeceasedForms_Employees_EmployeeID",
                table: "DeceasedForms");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeID",
                table: "DeceasedForms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeID2",
                table: "DeceasedForms",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeceasedForms_EmployeeID2",
                table: "DeceasedForms",
                column: "EmployeeID2");

            migrationBuilder.AddForeignKey(
                name: "FK_DeceasedForms_Employees_EmployeeID",
                table: "DeceasedForms",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeceasedForms_Employees_EmployeeID2",
                table: "DeceasedForms",
                column: "EmployeeID2",
                principalTable: "Employees",
                principalColumn: "EmployeeID");
        }
    }
}
