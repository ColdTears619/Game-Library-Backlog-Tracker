using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Game_Library_BackLog_Tracker.Migrations
{
    /// <inheritdoc />
    public partial class AddGameStore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameStores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    WebSiteUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameStores", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameStores_StoreName",
                table: "GameStores",
                column: "StoreName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameStores");
        }
    }
}
