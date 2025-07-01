using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Personal_Blog.Migrations
{
    /// <inheritdoc />
    public partial class FixStaticSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ID",
                keyValue: 1,
                column: "date",
                value: new DateTime(2025, 7, 1, 19, 16, 11, 40, DateTimeKind.Local).AddTicks(669));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ID",
                keyValue: 1,
                column: "date",
                value: new DateTime(2025, 7, 1, 19, 13, 26, 173, DateTimeKind.Local).AddTicks(9277));
        }
    }
}
