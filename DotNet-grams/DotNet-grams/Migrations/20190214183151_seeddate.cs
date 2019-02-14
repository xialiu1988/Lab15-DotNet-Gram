using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNet_grams.Migrations
{
    public partial class seeddate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "ID", "Description", "PosterName", "URL" },
                values: new object[,]
                {
                    { 1, "beach view", "xl", "beachview.jpg" },
                    { 2, "beach view", "xxl", "beachview.jpg" },
                    { 3, "cute kitty", "xxxl", "cute.jpg" },
                    { 4, "winter time", "xxxl", "wintertime.jpg" },
                    { 5, "happy hour", "xxxl", "happyhour.jpg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 5);
        }
    }
}
