using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ArgentumAtlas.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    PlatformId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.PlatformId);
                });

            migrationBuilder.CreateTable(
                name: "ServerInfos",
                columns: table => new
                {
                    ServerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: true),
                    Website = table.Column<string>(type: "TEXT", nullable: true),
                    Discord = table.Column<string>(type: "TEXT", nullable: true),
                    BannerURL = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServerInfos", x => x.ServerId);
                });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "PlatformId", "Name" },
                values: new object[,]
                {
                    { 1, "Windows" },
                    { 2, "Linux" },
                    { 3, "Mac" },
                    { 4, "Android" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Platforms");

            migrationBuilder.DropTable(
                name: "ServerInfos");
        }
    }
}
