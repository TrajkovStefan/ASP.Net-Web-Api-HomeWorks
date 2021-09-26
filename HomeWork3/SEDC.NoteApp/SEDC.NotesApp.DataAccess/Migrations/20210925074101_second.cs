using Microsoft.EntityFrameworkCore.Migrations;

namespace SEDC.NotesApp.DataAccess.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TagEnum",
                table: "Notes");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SSN",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Tag",
                table: "Notes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SSN",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Tag",
                table: "Notes");

            migrationBuilder.AddColumn<int>(
                name: "TagEnum",
                table: "Notes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
