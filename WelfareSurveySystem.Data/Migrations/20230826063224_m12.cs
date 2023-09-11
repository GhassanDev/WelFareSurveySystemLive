using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WelfareSurveySystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class m12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsEligibleToSharePensionAmount",
                table: "Spouses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEligibleToSharePensionAmount",
                table: "Siblings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEligibleToSharePensionAmount",
                table: "Parents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEligibleToSharePensionAmount",
                table: "Childrens",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEligibleToSharePensionAmount",
                table: "Spouses");

            migrationBuilder.DropColumn(
                name: "IsEligibleToSharePensionAmount",
                table: "Siblings");

            migrationBuilder.DropColumn(
                name: "IsEligibleToSharePensionAmount",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "IsEligibleToSharePensionAmount",
                table: "Childrens");
        }
    }
}
