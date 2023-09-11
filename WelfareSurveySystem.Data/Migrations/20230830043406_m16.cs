using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WelfareSurveySystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class m16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ManagerComment",
                table: "TaskStatuses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TopManagerComment",
                table: "TaskStatuses",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManagerComment",
                table: "TaskStatuses");

            migrationBuilder.DropColumn(
                name: "TopManagerComment",
                table: "TaskStatuses");
        }
    }
}
