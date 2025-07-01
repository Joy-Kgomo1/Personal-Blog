using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Personal_Blog.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    heading = table.Column<string>(type: "TEXT", nullable: false),
                    date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    content = table.Column<string>(type: "TEXT", maxLength: 5000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    username = table.Column<string>(type: "TEXT", nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ID", "content", "date", "heading" },
                values: new object[] { 1, "Artificial Intelligence (AI) has become an integral part of our daily lives. \r\nFrom personalized recommendations on streaming platforms to voice assistants in our homes, \r\nAI is transforming the way we live, work, and interact with technology.\r\n\r\nThe healthcare sector is leveraging AI to improve diagnostics and treatment planning, \r\nwhile industries like finance and retail are using it to predict trends and optimize operations.\r\n\r\nAs the technology continues to evolve, it is crucial to ensure responsible and ethical use of AI \r\nto maximize benefits while minimizing risks.", new DateTime(2025, 7, 1, 19, 13, 26, 173, DateTimeKind.Local).AddTicks(9277), "The Rise of AI in Everyday Life" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "password", "username" },
                values: new object[] { 1, "AdminPassword123", "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
