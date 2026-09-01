using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Game_Library_BackLog_Tracker.Migrations
{
    /// <inheritdoc />
    public partial class AddGameListings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameListings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StorePageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    GameStoreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameListings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameListings_GameStores_GameStoreId",
                        column: x => x.GameStoreId,
                        principalTable: "GameStores",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GameListings_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameListings_GameId_GameStoreId",
                table: "GameListings",
                columns: new[] { "GameId", "GameStoreId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameListings_GameStoreId",
                table: "GameListings",
                column: "GameStoreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameListings");
        }
    }
}
