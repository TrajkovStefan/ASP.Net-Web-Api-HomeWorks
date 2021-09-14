using Microsoft.EntityFrameworkCore.Migrations;

namespace SEDC.HomeWork.Class3.Migrations
{
    public partial class inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Title" },
                values: new object[] { 1, "Author1", "Book1" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Title" },
                values: new object[] { 2, "Author2", "Book2" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Title" },
                values: new object[] { 3, "Author3", "Book3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
