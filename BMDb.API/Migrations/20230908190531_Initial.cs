using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BMDb.API.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Poster = table.Column<string>(type: "text", nullable: true),
                    Year = table.Column<string>(type: "text", nullable: false),
                    Director = table.Column<string>(type: "text", nullable: false),
                    Genre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Director", "Genre", "Poster", "Title", "Year" },
                values: new object[,]
                {
                    { new Guid("0645d7db-6072-4107-83b9-4d0a2866d2a7"), "Frank Darabont", "Drama", "https://m.media-amazon.com/images/M/MV5BNDE3ODcxYzMtY2YzZC00NmNlLWJiNDMtZDViZWM2MzIxZDYwXkEyXkFqcGdeQXVyNjAwNDUxODI@._V1_SX300.jpg", "The Shawshank Redemption", "1994" },
                    { new Guid("5298d16e-739a-46fe-b432-af0993887a7a"), "Christopher Nolan", "Action, Crime, Drama", "https://m.media-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@._V1_SX300.jpg", "The Dark Knight", "2008" },
                    { new Guid("8245930e-2c01-4588-90ca-42294f499c8f"), "David Fincher", "Drama", "https://m.media-amazon.com/images/M/MV5BODQ0OWJiMzktYjNlYi00MzcwLThlZWMtMzRkYTY4ZDgxNzgxXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg", "Fight Club", "1999" },
                    { new Guid("8cf8ffc4-5290-4a72-a332-32078a779a1d"), "Francis Ford Coppola", "Crime, Drama", "https://m.media-amazon.com/images/M/MV5BM2MyNjYxNmUtYTAwNi00MTYxLWJmNWYtYzZlODY3ZTk3OTFlXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg", "The Godfather", "1972" },
                    { new Guid("b2f57cfb-1c4c-48e7-9cc1-b98330cfcf50"), "Peter Jackson", "Action, Adventure, Drama", "https://m.media-amazon.com/images/M/MV5BNzA5ZDNlZWMtM2NhNS00NDJjLTk4NDItYTRmY2EwMWZlMTY3XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg", "The Lord of the Rings: The Return of the King", "2003" },
                    { new Guid("c365cac0-6d7e-4181-9e36-d1cb594e3271"), "Christopher Nolan", "Action, Adventure", "https://m.media-amazon.com/images/M/MV5BMTk4ODQzNDY3Ml5BMl5BanBnXkFtZTcwODA0NTM4Nw@@._V1_SX300.jpg", "The Dark Knight Rises", "2012" },
                    { new Guid("cb6967ad-8166-4e85-9abb-027d9a96a7e7"), "Quentin Tarantino", "Crime, Drama", "https://m.media-amazon.com/images/M/MV5BNGNhMDIzZTUtNTBlZi00MTRlLWFjM2ItYzViMjE3YzI5MjljXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg", "Pulp Fiction", "1994" },
                    { new Guid("d480c22e-7906-4c4d-abcb-9e7c1d8b2fc8"), "Peter Jackson", "Action, Adventure, Drama", "https://m.media-amazon.com/images/M/MV5BN2EyZjM3NzUtNWUzMi00MTgxLWI0NTctMzY4M2VlOTdjZWRiXkEyXkFqcGdeQXVyNDUzOTQ5MjY@._V1_SX300.jpg", "The Lord of the Rings: The Fellowship of the Ring", "2001" },
                    { new Guid("dc17d0b3-6a2c-4389-b10e-c4c9e81b5504"), "Francis Ford Coppola", "Crime, Drama", "https://m.media-amazon.com/images/M/MV5BMWMwMGQzZTItY2JlNC00OWZiLWIyMDctNDk2ZDQ2YjRjMWQ0XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg", "The Godfather: Part II", "1974" },
                    { new Guid("f8d531e4-e74e-4d75-923e-2bd7beb89404"), "Lana Wachowski, Lilly Wachowski", "Action, Sci-Fi", "https://m.media-amazon.com/images/M/MV5BNzQzOTk3OTAtNDQ0Zi00ZTVkLWI0MTEtMDllZjNkYzNjNTc4L2ltYWdlXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_SX300.jpg", "The Matrix", "1999" },
                    { new Guid("ffa7c587-f2c9-4c20-96a7-c13fd497f51a"), "Steven Spielberg", "Biography, Drama, History", "https://m.media-amazon.com/images/M/MV5BNDE4OTMxMTctNmRhYy00NWE2LTg3YzItYTk3M2UwOTU5Njg4XkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_SX300.jpg", "Schindler's List", "1993" }
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
