using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WelfareSurveySystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class m14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "TaskStatuses",
                newName: "TopManagerStatus");

            migrationBuilder.AddColumn<string>(
                name: "ManagerStatus",
                table: "TaskStatuses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResearcherStatus",
                table: "TaskStatuses",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManagerStatus",
                table: "TaskStatuses");

            migrationBuilder.DropColumn(
                name: "ResearcherStatus",
                table: "TaskStatuses");

            migrationBuilder.RenameColumn(
                name: "TopManagerStatus",
                table: "TaskStatuses",
                newName: "Status");
        }
    }
}
