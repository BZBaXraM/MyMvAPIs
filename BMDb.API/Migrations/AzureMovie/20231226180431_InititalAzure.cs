﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BMDb.API.Migrations.AzureMovie
{
    /// <inheritdoc />
    public partial class InititalAzure : Migration
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
                    Trailer = table.Column<string>(type: "text", nullable: true),
                    Year = table.Column<string>(type: "text", nullable: false),
                    Director = table.Column<string>(type: "text", nullable: false),
                    Genre = table.Column<string>(type: "text", nullable: false),
                    Plot = table.Column<string>(type: "text", nullable: true),
                    ImdbId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Director", "Genre", "ImdbId", "Plot", "Poster", "Title", "Trailer", "Year" },
                values: new object[,]
                {
                    { new Guid("197ebd60-ac28-43ef-9914-e3e0e319f256"), "Francis Ford Coppola", "Crime, Drama", "tt0071562", "The early life and career of Vito Corleone in 1920s New York City is portrayed, while his son, Michael, expands and tightens his grip on the family crime syndicate.", "https://m.media-amazon.com/images/M/MV5BMWMwMGQzZTItY2JlNC00OWZiLWIyMDctNDk2ZDQ2YjRjMWQ0XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg", "The Godfather: Part II", null, "1974" },
                    { new Guid("1bcd02ab-60c8-40ca-ab9e-6d6a1d248759"), "Steven Spielberg", "Biography, Drama, History", "tt0108052", "In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis.", "https://m.media-amazon.com/images/M/MV5BNDE4OTMxMTctNmRhYy00NWE2LTg3YzItYTk3M2UwOTU5Njg4XkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_SX300.jpg", "Schindler's List", null, "1993" },
                    { new Guid("241d2e68-e81c-4512-97fb-1ff70391e916"), "Francis Ford Coppola", "Crime, Drama", "tt0068646", "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.", "https://m.media-amazon.com/images/M/MV5BM2MyNjYxNmUtYTAwNi00MTYxLWJmNWYtYzZlODY3ZTk3OTFlXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg", "The Godfather", null, "1972" },
                    { new Guid("7bc07cad-7da4-4d09-8876-6f26b5255fdc"), "Christopher Nolan", "Action, Crime, Drama", "tt0468569", "The Dark Knight of Gotham City begins his war on crime with his first major enemy being Jack Napier, a criminal who becomes the clownishly homicidal Joker.", "https://m.media-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@._V1_SX300.jpg", "The Dark Knight", null, "2008" },
                    { new Guid("7c8aed6d-1bff-48be-8e93-49ec69acdc21"), "Martin Scorsese", "Biography, Crime, Drama", "tt0099685", "The story of Henry Hill and his life in the mob, covering his relationship with his wife Karen Hill and his mob partners Jimmy Conway and Tommy DeVito in the Italian-American crime syndicate.", "https://m.media-amazon.com/images/M/MV5BY2NkZjEzMDgtN2RjYy00YzM1LWI4ZmQtMjIwYjFjNmI3ZGEwXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg", "Goodfellas", null, "1990" },
                    { new Guid("8367f20a-f936-4476-a41e-542d766b3b08"), "Sam Raimi", "Action, Adventure, Sci-Fi", "tt0145487", "When bitten by a genetically modified spider, a nerdy, shy, and awkward high school student gains spider-like abilities that he eventually must use to fight evil as a superhero after tragedy befalls his family.", "https://m.media-amazon.com/images/M/MV5BZDEyN2NhMjgtMjdhNi00MmNlLWE5YTgtZGE4MzNjMTRlMGEwXkEyXkFqcGdeQXVyNDUyOTg3Njg@._V1_SX300.jpg", "Spider Man", null, "2002" },
                    { new Guid("89d87917-27fe-4280-ad16-5eec9b263bdc"), "David Fincher", "Biography, Drama", "tt1285016", "As Harvard student Mark Zuckerberg creates the social networking site that would become known as Facebook, he is sued by the twins who claimed he stole their idea, and by the co-founder who was later squeezed out of the business.", "https://m.media-amazon.com/images/M/MV5BOGUyZDUxZjEtMmIzMC00MzlmLTg4MGItZWJmMzBhZjE0Mjc1XkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_SX300.jpg", "The Social Network", null, "2010" },
                    { new Guid("a6b6aefd-cdc1-4c37-a8a2-4f0c1c3429c4"), "Christopher Nolan", "Action, Adventure", "tt1345836", "Eight years after the Joker's reign of chaos, Batman is coerced out of exile with the assistance of the mysterious Selina Kyle in order to defend Gotham City from the vicious guerrilla terrorist Bane.", "https://m.media-amazon.com/images/M/MV5BMTk4ODQzNDY3Ml5BMl5BanBnXkFtZTcwODA0NTM4Nw@@._V1_SX300.jpg", "The Dark Knight Rises", null, "2012" },
                    { new Guid("b5bdc318-abcc-46c2-b9a5-2c13f5000858"), "Sam Raimi", "Action, Adventure, Sci-Fi", "tt0316654", "Peter Parker is beset with troubles in his failing personal life as he battles a brilliant scientist named Doctor Otto Octavius.", "https://m.media-amazon.com/images/M/MV5BMzY2ODk4NmUtOTVmNi00ZTdkLTlmOWYtMmE2OWVhNTU2OTVkXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_SX300.jpg", "Spider Man 2", null, "2004" },
                    { new Guid("cb4cba77-fc31-464a-8479-64ba53938630"), "Sam Raimi", "Action, Adventure, Sci-Fi", "tt0413300", "A strange black entity from another world bonds with Peter Parker and causes inner turmoil as he contends with new villains, temptations, and revenge.", "https://m.media-amazon.com/images/M/MV5BYTk3MDljOWQtNGI2My00OTEzLTlhYjQtOTQ4ODM2MzUwY2IwXkEyXkFqcGdeQXVyNTIzOTk5ODM@._V1_SX300.jpg", "Spider Man 3", null, "2007" },
                    { new Guid("d51548bc-4a18-49bd-9bbc-04529b5ca779"), "Quentin Tarantino", "Crime, Drama", "tt0110912", "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.", "https://m.media-amazon.com/images/M/MV5BNGNhMDIzZTUtNTBlZi00MTRlLWFjM2ItYzViMjE3YzI5MjljXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg", "Pulp Fiction", null, "1994" },
                    { new Guid("e63f1b6c-c8ae-4d27-8933-592771477ee4"), "David Fincher", "Drama", "tt0137523", "An insomniac office worker and a devil-may-care soapmaker form an underground fight club that evolves into something much, much more.", "https://m.media-amazon.com/images/M/MV5BODQ0OWJiMzktYjNlYi00MzcwLThlZWMtMzRkYTY4ZDgxNzgxXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg", "Fight Club", null, "1999" },
                    { new Guid("ed211582-b3ca-4496-ad45-6fde08ecdd57"), "Lana Wachowski, Lilly Wachowski", "Action, Sci-Fi", "tt0133093", "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.", "https://m.media-amazon.com/images/M/MV5BNzQzOTk3OTAtNDQ0Zi00ZTVkLWI0MTEtMDllZjNkYzNjNTc4L2ltYWdlXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_SX300.jpg", "The Matrix", null, "1999" },
                    { new Guid("f1e9c335-261b-4668-8580-15eecce185e5"), "Joseph Kosinski", "Action, Adventure, Sci-Fi", "tt1104001", "The son of a virtual world designer goes looking for his father and ends up inside the digital world that his father designed. He meets his father's corrupted creation and a unique ally who was born inside the digital world.", "https://m.media-amazon.com/images/M/MV5BMTk4NTk4MTk1OF5BMl5BanBnXkFtZTcwNTE2MDIwNA@@._V1_SX300.jpg", "Tron: Legacy", null, "2010" },
                    { new Guid("f60ff3ed-ba74-4bcf-8126-76d649320857"), "Steven Lisberger", "Action, Adventure, Sci-Fi", "tt0084827", "A computer hacker is abducted into the digital world and forced to participate in gladiatorial games where his only chance of escape is with the help of a heroic security program.", "https://m.media-amazon.com/images/M/MV5BZjgxYzk3NjItNDliMC00YzE5LWEzZDQtZjJjZWUyNjE2MGFkXkEyXkFqcGdeQXVyMTUzMDUzNTI3._V1_SX300.jpg", "Tron", null, "1982" },
                    { new Guid("f6f66bc0-1a89-418f-a992-019c8fdd409d"), "Frank Darabont", "Drama", "tt0111161", "Over the course of several years, two convicts form a friendship, seeking consolation and, eventually, redemption through basic compassion.", "https://m.media-amazon.com/images/M/MV5BNDE3ODcxYzMtY2YzZC00NmNlLWJiNDMtZDViZWM2MzIxZDYwXkEyXkFqcGdeQXVyNjAwNDUxODI@._V1_SX300.jpg", "The Shawshank Redemption", "https://www.youtube.com/watch?v=6hB3S9bIaco", "1994" }
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
