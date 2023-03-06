using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArgentumAtlas.Migrations
{
    /// <inheritdoc />
    public partial class ChangeIcon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "PlatformId",
                keyValue: 1,
                column: "IconURL",
                value: "/images/os/windows.png");

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "PlatformId",
                keyValue: 2,
                column: "IconURL",
                value: "/images/os/linux.png");

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "PlatformId",
                keyValue: 3,
                column: "IconURL",
                value: "/images/os/mac.png");

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "PlatformId",
                keyValue: 4,
                column: "IconURL",
                value: "/images/os/android.png");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "PlatformId",
                keyValue: 1,
                column: "IconURL",
                value: "~/images/os/windows.png");

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "PlatformId",
                keyValue: 2,
                column: "IconURL",
                value: "~/images/os/linux.png");

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "PlatformId",
                keyValue: 3,
                column: "IconURL",
                value: "~/images/os/mac.png");

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "PlatformId",
                keyValue: 4,
                column: "IconURL",
                value: "~/images/os/android.png");
        }
    }
}
