using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BMDb.API.Migrations.AzureMovie
{
    /// <inheritdoc />
    public partial class InititalAzureIdentity : Migration
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
                    { new Guid("0f842031-166c-473d-91bc-3ad895c407d1"), "Frank Darabont", "Drama", "tt0111161", "Over the course of several years, two convicts form a friendship, seeking consolation and, eventually, redemption through basic compassion.", "https://m.media-amazon.com/images/M/MV5BNDE3ODcxYzMtY2YzZC00NmNlLWJiNDMtZDViZWM2MzIxZDYwXkEyXkFqcGdeQXVyNjAwNDUxODI@._V1_SX300.jpg", "The Shawshank Redemption", "https://www.youtube.com/watch?v=6hB3S9bIaco", "1994" },
                    { new Guid("1d2abf0e-5d8d-4bc3-8f7c-939075a0be47"), "Christopher Nolan", "Action, Adventure", "tt1345836", "Eight years after the Joker's reign of chaos, Batman is coerced out of exile with the assistance of the mysterious Selina Kyle in order to defend Gotham City from the vicious guerrilla terrorist Bane.", "https://m.media-amazon.com/images/M/MV5BMTk4ODQzNDY3Ml5BMl5BanBnXkFtZTcwODA0NTM4Nw@@._V1_SX300.jpg", "The Dark Knight Rises", null, "2012" },
                    { new Guid("23174d2a-dd31-44c1-bfa0-b629bccbfd72"), "Sam Raimi", "Action, Adventure, Sci-Fi", "tt0413300", "A strange black entity from another world bonds with Peter Parker and causes inner turmoil as he contends with new villains, temptations, and revenge.", "https://m.media-amazon.com/images/M/MV5BYTk3MDljOWQtNGI2My00OTEzLTlhYjQtOTQ4ODM2MzUwY2IwXkEyXkFqcGdeQXVyNTIzOTk5ODM@._V1_SX300.jpg", "Spider Man 3", null, "2007" },
                    { new Guid("380e49db-2888-40f6-969d-5d7587c4aee4"), "Francis Ford Coppola", "Crime, Drama", "tt0068646", "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.", "https://m.media-amazon.com/images/M/MV5BM2MyNjYxNmUtYTAwNi00MTYxLWJmNWYtYzZlODY3ZTk3OTFlXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg", "The Godfather", null, "1972" },
                    { new Guid("3e44f2e9-4afe-454b-812c-2e20896c14d5"), "Lana Wachowski, Lilly Wachowski", "Action, Sci-Fi", "tt0133093", "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.", "https://m.media-amazon.com/images/M/MV5BNzQzOTk3OTAtNDQ0Zi00ZTVkLWI0MTEtMDllZjNkYzNjNTc4L2ltYWdlXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_SX300.jpg", "The Matrix", null, "1999" },
                    { new Guid("66d8c152-6d03-4a6f-a207-ebf0918c0ea8"), "Joseph Kosinski", "Action, Adventure, Sci-Fi", "tt1104001", "The son of a virtual world designer goes looking for his father and ends up inside the digital world that his father designed. He meets his father's corrupted creation and a unique ally who was born inside the digital world.", "https://m.media-amazon.com/images/M/MV5BMTk4NTk4MTk1OF5BMl5BanBnXkFtZTcwNTE2MDIwNA@@._V1_SX300.jpg", "Tron: Legacy", null, "2010" },
                    { new Guid("7343acaf-bf91-4cd8-9030-4a930045d336"), "Steven Spielberg", "Biography, Drama, History", "tt0108052", "In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis.", "https://m.media-amazon.com/images/M/MV5BNDE4OTMxMTctNmRhYy00NWE2LTg3YzItYTk3M2UwOTU5Njg4XkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_SX300.jpg", "Schindler's List", null, "1993" },
                    { new Guid("7408115c-7809-4d6b-8b4e-3d79ed304869"), "Sam Raimi", "Action, Adventure, Sci-Fi", "tt0316654", "Peter Parker is beset with troubles in his failing personal life as he battles a brilliant scientist named Doctor Otto Octavius.", "https://m.media-amazon.com/images/M/MV5BMzY2ODk4NmUtOTVmNi00ZTdkLTlmOWYtMmE2OWVhNTU2OTVkXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_SX300.jpg", "Spider Man 2", null, "2004" },
                    { new Guid("7858a249-e0fd-4773-94d8-2cfffcb04fb4"), "Sam Raimi", "Action, Adventure, Sci-Fi", "tt0145487", "When bitten by a genetically modified spider, a nerdy, shy, and awkward high school student gains spider-like abilities that he eventually must use to fight evil as a superhero after tragedy befalls his family.", "https://m.media-amazon.com/images/M/MV5BZDEyN2NhMjgtMjdhNi00MmNlLWE5YTgtZGE4MzNjMTRlMGEwXkEyXkFqcGdeQXVyNDUyOTg3Njg@._V1_SX300.jpg", "Spider Man", null, "2002" },
                    { new Guid("838e5d23-39f5-4c4d-b922-2388d5a4ffdb"), "Steven Lisberger", "Action, Adventure, Sci-Fi", "tt0084827", "A computer hacker is abducted into the digital world and forced to participate in gladiatorial games where his only chance of escape is with the help of a heroic security program.", "https://m.media-amazon.com/images/M/MV5BZjgxYzk3NjItNDliMC00YzE5LWEzZDQtZjJjZWUyNjE2MGFkXkEyXkFqcGdeQXVyMTUzMDUzNTI3._V1_SX300.jpg", "Tron", null, "1982" },
                    { new Guid("9aa325e0-fc8d-4043-9c3e-09b06bd27183"), "Quentin Tarantino", "Crime, Drama", "tt0110912", "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.", "https://m.media-amazon.com/images/M/MV5BNGNhMDIzZTUtNTBlZi00MTRlLWFjM2ItYzViMjE3YzI5MjljXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg", "Pulp Fiction", null, "1994" },
                    { new Guid("aff7fc44-5b65-4cce-88b1-1cd611b77a26"), "Francis Ford Coppola", "Crime, Drama", "tt0071562", "The early life and career of Vito Corleone in 1920s New York City is portrayed, while his son, Michael, expands and tightens his grip on the family crime syndicate.", "https://m.media-amazon.com/images/M/MV5BMWMwMGQzZTItY2JlNC00OWZiLWIyMDctNDk2ZDQ2YjRjMWQ0XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg", "The Godfather: Part II", null, "1974" },
                    { new Guid("bc6ad3a0-a594-4542-a083-975dec88bd05"), "Christopher Nolan", "Action, Crime, Drama", "tt0468569", "The Dark Knight of Gotham City begins his war on crime with his first major enemy being Jack Napier, a criminal who becomes the clownishly homicidal Joker.", "https://m.media-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@._V1_SX300.jpg", "The Dark Knight", null, "2008" },
                    { new Guid("bd7a0824-1296-4089-bb15-271fd9020fc6"), "David Fincher", "Drama", "tt0137523", "An insomniac office worker and a devil-may-care soapmaker form an underground fight club that evolves into something much, much more.", "https://m.media-amazon.com/images/M/MV5BODQ0OWJiMzktYjNlYi00MzcwLThlZWMtMzRkYTY4ZDgxNzgxXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg", "Fight Club", null, "1999" },
                    { new Guid("d5aa260b-90ff-4ce4-a0f8-f003dc5d806f"), "David Fincher", "Biography, Drama", "tt1285016", "As Harvard student Mark Zuckerberg creates the social networking site that would become known as Facebook, he is sued by the twins who claimed he stole their idea, and by the co-founder who was later squeezed out of the business.", "https://m.media-amazon.com/images/M/MV5BOGUyZDUxZjEtMmIzMC00MzlmLTg4MGItZWJmMzBhZjE0Mjc1XkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_SX300.jpg", "The Social Network", null, "2010" },
                    { new Guid("ee6c5c09-ff00-412f-84c3-cc9bbd9791fb"), "Martin Scorsese", "Biography, Crime, Drama", "tt0099685", "The story of Henry Hill and his life in the mob, covering his relationship with his wife Karen Hill and his mob partners Jimmy Conway and Tommy DeVito in the Italian-American crime syndicate.", "https://m.media-amazon.com/images/M/MV5BY2NkZjEzMDgtN2RjYy00YzM1LWI4ZmQtMjIwYjFjNmI3ZGEwXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg", "Goodfellas", null, "1990" }
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
