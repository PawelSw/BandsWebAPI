using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BandsWebAPI.Migrations
{
    public partial class InitialAndSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bands",
                columns: table => new
                {
                    BandId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    DateOfFoundation = table.Column<int>(type: "INTEGER", maxLength: 10, nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bands", x => x.BandId);
                });

            migrationBuilder.CreateTable(
                name: "Musicians",
                columns: table => new
                {
                    MusicianId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Role = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musicians", x => x.MusicianId);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    AlbumId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    DateOfRelease = table.Column<int>(type: "INTEGER", maxLength: 20, nullable: false),
                    BandId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.AlbumId);
                    table.ForeignKey(
                        name: "FK_Albums_Bands_BandId",
                        column: x => x.BandId,
                        principalTable: "Bands",
                        principalColumn: "BandId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Descriptions",
                columns: table => new
                {
                    DescriptionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Genres = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    BandId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descriptions", x => x.DescriptionId);
                    table.ForeignKey(
                        name: "FK_Descriptions_Bands_BandId",
                        column: x => x.BandId,
                        principalTable: "Bands",
                        principalColumn: "BandId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BandMusician",
                columns: table => new
                {
                    BandsBandId = table.Column<int>(type: "INTEGER", nullable: false),
                    MusiciansMusicianId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BandMusician", x => new { x.BandsBandId, x.MusiciansMusicianId });
                    table.ForeignKey(
                        name: "FK_BandMusician_Bands_BandsBandId",
                        column: x => x.BandsBandId,
                        principalTable: "Bands",
                        principalColumn: "BandId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BandMusician_Musicians_MusiciansMusicianId",
                        column: x => x.MusiciansMusicianId,
                        principalTable: "Musicians",
                        principalColumn: "MusicianId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MusicianBands",
                columns: table => new
                {
                    MusicianBandsId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MusicianId = table.Column<int>(type: "INTEGER", nullable: false),
                    BandId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicianBands", x => x.MusicianBandsId);
                    table.ForeignKey(
                        name: "FK_MusicianBands_Bands_BandId",
                        column: x => x.BandId,
                        principalTable: "Bands",
                        principalColumn: "BandId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusicianBands_Musicians_MusicianId",
                        column: x => x.MusicianId,
                        principalTable: "Musicians",
                        principalColumn: "MusicianId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Bands",
                columns: new[] { "BandId", "DateOfFoundation", "IsActive", "Name" },
                values: new object[] { 1, 1990, false, "Tool" });

            migrationBuilder.InsertData(
                table: "Bands",
                columns: new[] { "BandId", "DateOfFoundation", "IsActive", "Name" },
                values: new object[] { 2, 1981, false, "Napalm Death" });

            migrationBuilder.InsertData(
                table: "Musicians",
                columns: new[] { "MusicianId", "Name", "Role" },
                values: new object[] { 1, "Maynard James Keenan", "Vocal" });

            migrationBuilder.InsertData(
                table: "Musicians",
                columns: new[] { "MusicianId", "Name", "Role" },
                values: new object[] { 2, "Mark Barney Greenway", "Vocal" });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "AlbumId", "BandId", "DateOfRelease", "Title" },
                values: new object[] { 1, 1, 1992, "Opiate" });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "AlbumId", "BandId", "DateOfRelease", "Title" },
                values: new object[] { 2, 2, 1990, "Harmony Corruption" });

            migrationBuilder.InsertData(
                table: "Descriptions",
                columns: new[] { "DescriptionId", "BandId", "Genres" },
                values: new object[] { 1, 1, "Alternative metal" });

            migrationBuilder.InsertData(
                table: "Descriptions",
                columns: new[] { "DescriptionId", "BandId", "Genres" },
                values: new object[] { 2, 2, "Death metal" });

            migrationBuilder.InsertData(
                table: "MusicianBands",
                columns: new[] { "MusicianBandsId", "BandId", "MusicianId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "MusicianBands",
                columns: new[] { "MusicianBandsId", "BandId", "MusicianId" },
                values: new object[] { 2, 2, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_BandId",
                table: "Albums",
                column: "BandId");

            migrationBuilder.CreateIndex(
                name: "IX_BandMusician_MusiciansMusicianId",
                table: "BandMusician",
                column: "MusiciansMusicianId");

            migrationBuilder.CreateIndex(
                name: "IX_Descriptions_BandId",
                table: "Descriptions",
                column: "BandId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MusicianBands_BandId",
                table: "MusicianBands",
                column: "BandId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicianBands_MusicianId",
                table: "MusicianBands",
                column: "MusicianId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "BandMusician");

            migrationBuilder.DropTable(
                name: "Descriptions");

            migrationBuilder.DropTable(
                name: "MusicianBands");

            migrationBuilder.DropTable(
                name: "Bands");

            migrationBuilder.DropTable(
                name: "Musicians");
        }
    }
}
