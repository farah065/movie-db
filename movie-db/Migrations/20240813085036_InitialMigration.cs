using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace movie_db.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Adult = table.Column<bool>(type: "bit", nullable: true),
                    BackdropPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BelongsToCollection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Budget = table.Column<int>(type: "int", nullable: true),
                    Genres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Homepage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImdbId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalLanguage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Overview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Popularity = table.Column<double>(type: "float", nullable: true),
                    PosterPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductionCompanies = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductionCountries = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Revenue = table.Column<int>(type: "int", nullable: true),
                    Runtime = table.Column<int>(type: "int", nullable: true),
                    SpokenLanguages = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tagline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Video = table.Column<bool>(type: "bit", nullable: true),
                    VoteAverage = table.Column<double>(type: "float", nullable: true),
                    VoteCount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
