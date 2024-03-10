using BMDb.API.Entities;
using BMDb.API.Models;
using BMDb.API.Services;
using Microsoft.EntityFrameworkCore;
using EntityFrameworkCoreMock;

namespace BMDb.UnitTests;

public class UnitTest1
{
    private readonly IAsyncMovieService _movieService;

    public UnitTest1()
    {
        var moviesInitialData = new List<Movie>();
        var dbContextMock = new DbContextMock<MovieContext>(
            new DbContextOptionsBuilder<MovieContext>().Options
        );

        var dbContext = dbContextMock.Object;
        dbContextMock.CreateDbSetMock(x => x.Movies, moviesInitialData);
        _movieService = new MovieService(dbContext);
    }

    [Fact]
    public async Task Add_Movie_Test()
    {
        Movie movie = new()
        {
            Director = "Serdar Akar",
            Genre = "Action",
            Poster = null,
            Trailer = null,
            Title = "Kurtlar Vadisi Irak",
            Year = "2006",
            Plot = null,
            Id = Guid.NewGuid()
        };

        var dbContextMock = new DbContextMock<MovieContext>(
            new DbContextOptionsBuilder<MovieContext>().Options
        );

        dbContextMock.CreateDbSetMock(x => x.Movies, new List<Movie>());

        var addedMovie = await _movieService.AddMovieAsync(movie);

        Assert.NotNull(addedMovie);
        Assert.Equal(movie.Id, addedMovie.Id);
        Assert.Equal(movie.Director, addedMovie.Director);
        Assert.Equal(movie.Genre, addedMovie.Genre);
        Assert.Equal(movie.Poster, addedMovie.Poster);
        Assert.Equal(movie.Trailer, addedMovie.Trailer);
        Assert.Equal(movie.Title, addedMovie.Title);
        Assert.Equal(movie.Year, addedMovie.Year);
        Assert.Equal(movie.Plot, addedMovie.Plot);
    }

    [Fact]
    public async Task Get_Movies_Test()
    {
        var movies = new List<Movie>
        {
            new()
            {
                Director = "Serdar Akar",
                Genre = "Action",
                Poster = null,
                Trailer = null,
                Title = "Kurtlar Vadisi Irak",
                Year = "2006",
                Plot = null,
                Id = Guid.NewGuid()
            },
            new()
            {
                Director = "Serdar Akar",
                Genre = "Action",
                Poster = null,
                Trailer = null,
                Title = "Kurtlar Vadisi Irak",
                Year = "2006",
                Plot = null,
                Id = Guid.NewGuid()
            }
        };

        var dbContextMock = new DbContextMock<MovieContext>(
            new DbContextOptionsBuilder<MovieContext>().Options
        );

        dbContextMock.CreateDbSetMock(x => x.Movies, movies);

        var movieService = new MovieService(dbContextMock.Object);

        var result = await movieService.GetMoviesAsync("1", "10", "title");

        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public async Task Delete_Movie_By_Id_Test()
    {
        var movieId = Guid.NewGuid();
        var movies = new List<Movie>
        {
            new()
            {
                Director = "Serdar Akar",
                Genre = "Action",
                Poster = null,
                Trailer = null,
                Title = "Kurtlar Vadisi Irak",
                Year = "2006",
                Plot = null,
                Id = movieId
            },
            new()
            {
                Director = "Serdar Akar",
                Genre = "Action",
                Poster = null,
                Trailer = null,
                Title = "Kurtlar Vadisi Irak",
                Year = "2006",
                Plot = null,
                Id = Guid.NewGuid()
            }
        };

        var dbContextMock = new DbContextMock<MovieContext>(
            new DbContextOptionsBuilder<MovieContext>().Options
        );

        dbContextMock.CreateDbSetMock(x => x.Movies, movies);

        var movieService = new MovieService(dbContextMock.Object);

        await movieService.DeleteMovieAsync(movieId);

        var deletedMovie = await movieService.GetMovieByIdAsync(movieId);
        Assert.Null(deletedMovie);
    }
}