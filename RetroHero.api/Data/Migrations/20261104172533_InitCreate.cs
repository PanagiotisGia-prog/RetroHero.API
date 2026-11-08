using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RetroHero.api.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DbGenre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbGenre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbPlatform",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbPlatform", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbGames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    GenreId = table.Column<int>(type: "INTEGER", nullable: false),
                    PlatformId = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Release = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbGames_DbGenre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "DbGenre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DbGames_DbPlatform_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "DbPlatform",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DbGames_GenreId",
                table: "DbGames",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_DbGames_PlatformId",
                table: "DbGames",
                column: "PlatformId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbGames");

            migrationBuilder.DropTable(
                name: "DbGenre");

            migrationBuilder.DropTable(
                name: "DbPlatform");
        }
    }
}
