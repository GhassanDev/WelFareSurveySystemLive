using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WelfareSurveySystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class m2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeceasedForms_Employees_EmployeeID1",
                table: "DeceasedForms");

            migrationBuilder.DropIndex(
                name: "IX_DeceasedForms_EmployeeID1",
                table: "DeceasedForms");

            migrationBuilder.DropColumn(
                name: "EmployeeID1",
                table: "DeceasedForms");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeID1",
                table: "DeceasedForms",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeceasedForms_EmployeeID1",
                table: "DeceasedForms",
                column: "EmployeeID1");

            migrationBuilder.AddForeignKey(
                name: "FK_DeceasedForms_Employees_EmployeeID1",
                table: "DeceasedForms",
                column: "EmployeeID1",
                principalTable: "Employees",
                principalColumn: "EmployeeID");
        }
    }
}
