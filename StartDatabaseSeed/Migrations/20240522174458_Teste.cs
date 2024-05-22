using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StartDatabaseSeed.Migrations
{
    /// <inheritdoc />
    public partial class Teste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ItemsCatalog",
                columns: table => new
                {
                    TmdbId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OriginalTitle = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsCatalog", x => x.TmdbId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Streamings",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HomePage = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Streamings", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "GenreItemCatalog",
                columns: table => new
                {
                    GenresId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ItemsTmdbId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreItemCatalog", x => new { x.GenresId, x.ItemsTmdbId });
                    table.ForeignKey(
                        name: "FK_GenreItemCatalog_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreItemCatalog_ItemsCatalog_ItemsTmdbId",
                        column: x => x.ItemsTmdbId,
                        principalTable: "ItemsCatalog",
                        principalColumn: "TmdbId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "addons",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HomePage = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StreamingId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_addons_Streamings_StreamingId",
                        column: x => x.StreamingId,
                        principalTable: "Streamings",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ItemsCatalog_Streamings",
                columns: table => new
                {
                    ItemCatologId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StreamingId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    expiresSoon = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Price = table.Column<double>(type: "double", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Link = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsCatalog_Streamings", x => new { x.ItemCatologId, x.StreamingId });
                    table.ForeignKey(
                        name: "FK_ItemsCatalog_Streamings_ItemsCatalog_ItemCatalogTmdbId",
                        column: x => x.ItemCatalogTmdbId,
                        principalTable: "ItemsCatalog",
                        principalColumn: "TmdbId");
                    table.ForeignKey(
                        name: "FK_ItemsCatalog_Streamings_Streamings_StreamingId",
                        column: x => x.StreamingId,
                        principalTable: "Streamings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_addons_StreamingId",
                table: "addons",
                column: "StreamingId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreItemCatalog_ItemsTmdbId",
                table: "GenreItemCatalog",
                column: "ItemsTmdbId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsCatalog_Streamings_ItemCatalogTmdbId",
                table: "ItemsCatalog_Streamings",
                column: "ItemCatalogTmdbId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsCatalog_Streamings_StreamingId",
                table: "ItemsCatalog_Streamings",
                column: "StreamingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "addons");

            migrationBuilder.DropTable(
                name: "GenreItemCatalog");

            migrationBuilder.DropTable(
                name: "ItemsCatalog_Streamings");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "ItemsCatalog");

            migrationBuilder.DropTable(
                name: "Streamings");
        }
    }
}
