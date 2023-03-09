using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArgentumAtlas.Migrations
{
    /// <inheritdoc />
    public partial class Wda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServerPlatforms",
                columns: table => new
                {
                    PlatformId = table.Column<int>(type: "INTEGER", nullable: false),
                    ServerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServerPlatforms", x => new { x.ServerId, x.PlatformId });
                    table.ForeignKey(
                        name: "FK_ServerPlatforms_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "PlatformId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServerPlatforms_ServerInfos_ServerId",
                        column: x => x.ServerId,
                        principalTable: "ServerInfos",
                        principalColumn: "ServerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServerPlatforms_PlatformId",
                table: "ServerPlatforms",
                column: "PlatformId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServerPlatforms");
        }
    }
}
