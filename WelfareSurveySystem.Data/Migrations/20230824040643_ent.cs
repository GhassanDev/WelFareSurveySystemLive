using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WelfareSurveySystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class ent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Branch",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Branch",
                table: "Employees");
        }
    }
}
