using BMDb.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BMDb.API.Data;

/// <inheritdoc />
public class MovieContext : DbContext
{
    /// <inheritdoc />
    public MovieContext(DbContextOptions<MovieContext> options) : base(options)
    {
    }

    ///<interitdoc />
    public virtual DbSet<Movie> Movies => Set<Movie>();

    /// <summary>
    /// 
    /// </summary>
    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var movies = new List<Movie>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Title = "The Shawshank Redemption",
                Year = "1994",
                Director = "Frank Darabont",
                Genre = "Drama",
                Poster =
                    "https://m.media-amazon.com/images/M/MV5BNDE3ODcxYzMtY2YzZC00NmNlLWJiNDMtZDViZWM2MzIxZDYwXkEyXkFqcGdeQXVyNjAwNDUxODI@._V1_SX300.jpg"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "The Godfather",
                Year = "1972",
                Director = "Francis Ford Coppola",
                Genre = "Crime, Drama",
                Poster =
                    "https://m.media-amazon.com/images/M/MV5BM2MyNjYxNmUtYTAwNi00MTYxLWJmNWYtYzZlODY3ZTk3OTFlXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "The Dark Knight",
                Year = "2008",
                Director = "Christopher Nolan",
                Genre = "Action, Crime, Drama",
                Poster =
                    "https://m.media-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@._V1_SX300.jpg"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "The Dark Knight Rises",
                Year = "2012",
                Director = "Christopher Nolan",
                Genre = "Action, Adventure",
                Poster =
                    "https://m.media-amazon.com/images/M/MV5BMTk4ODQzNDY3Ml5BMl5BanBnXkFtZTcwODA0NTM4Nw@@._V1_SX300.jpg"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "The Godfather: Part II",
                Year = "1974",
                Director = "Francis Ford Coppola",
                Genre = "Crime, Drama",
                Poster =
                    "https://m.media-amazon.com/images/M/MV5BMWMwMGQzZTItY2JlNC00OWZiLWIyMDctNDk2ZDQ2YjRjMWQ0XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "The Lord of the Rings: The Return of the King",
                Year = "2003",
                Director = "Peter Jackson",
                Genre = "Action, Adventure, Drama",
                Poster =
                    "https://m.media-amazon.com/images/M/MV5BNzA5ZDNlZWMtM2NhNS00NDJjLTk4NDItYTRmY2EwMWZlMTY3XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Pulp Fiction",
                Year = "1994",
                Director = "Quentin Tarantino",
                Genre = "Crime, Drama",
                Poster =
                    "https://m.media-amazon.com/images/M/MV5BNGNhMDIzZTUtNTBlZi00MTRlLWFjM2ItYzViMjE3YzI5MjljXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Schindler's List",
                Year = "1993",
                Director = "Steven Spielberg",
                Genre = "Biography, Drama, History",
                Poster =
                    "https://m.media-amazon.com/images/M/MV5BNDE4OTMxMTctNmRhYy00NWE2LTg3YzItYTk3M2UwOTU5Njg4XkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_SX300.jpg"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "The Lord of the Rings: The Fellowship of the Ring",
                Year = "2001",
                Director = "Peter Jackson",
                Genre = "Action, Adventure, Drama",
                Poster =
                    "https://m.media-amazon.com/images/M/MV5BN2EyZjM3NzUtNWUzMi00MTgxLWI0NTctMzY4M2VlOTdjZWRiXkEyXkFqcGdeQXVyNDUzOTQ5MjY@._V1_SX300.jpg"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Fight Club",
                Year = "1999",
                Director = "David Fincher",
                Genre = "Drama",
                Poster =
                    "https://m.media-amazon.com/images/M/MV5BODQ0OWJiMzktYjNlYi00MzcwLThlZWMtMzRkYTY4ZDgxNzgxXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "The Matrix",
                Year = "1999",
                Director = "Lana Wachowski, Lilly Wachowski",
                Genre = "Action, Sci-Fi",
                Poster =
                    "https://m.media-amazon.com/images/M/MV5BNzQzOTk3OTAtNDQ0Zi00ZTVkLWI0MTEtMDllZjNkYzNjNTc4L2ltYWdlXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_SX300.jpg"
            }
        };

        modelBuilder.Entity<Movie>().HasData(movies);
    }
}