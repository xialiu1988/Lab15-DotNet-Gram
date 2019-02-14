using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNet_grams.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 1,
                column: "URL",
                value: "https://via.placeholder.com/300?text=DotNetGram");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 2,
                column: "URL",
                value: "https://via.placeholder.com/300?text=DotNetGram");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 3,
                column: "URL",
                value: "https://via.placeholder.com/300?text=DotNetGram");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 4,
                column: "URL",
                value: "https://via.placeholder.com/300?text=DotNetGram");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 5,
                column: "URL",
                value: "https://via.placeholder.com/300?text=DotNetGram");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 1,
                column: "URL",
                value: "beachview.jpg");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 2,
                column: "URL",
                value: "beachview.jpg");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 3,
                column: "URL",
                value: "cute.jpg");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 4,
                column: "URL",
                value: "wintertime.jpg");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 5,
                column: "URL",
                value: "happyhour.jpg");
        }
    }
}
