using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNet_grams.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PosterName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "ID", "Description", "PosterName", "URL" },
                values: new object[,]
                {
                    { 1, "beach view", "xl", "https://via.placeholder.com/200?text=DotNetGram" },
                    { 2, "beach view", "xxl", "https://via.placeholder.com/200?text=DotNetGram" },
                    { 3, "cute kitty", "xxxl", "https://via.placeholder.com/200?text=DotNetGram" },
                    { 4, "winter time", "xxxl", "https://via.placeholder.com/200?text=DotNetGram" },
                    { 5, "happy hour", "xxxl", "https://via.placeholder.com/200?text=DotNetGram" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
