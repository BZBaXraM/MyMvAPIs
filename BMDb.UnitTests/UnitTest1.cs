using BMDb.API.DTOs;
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
        // Arrange
        AddMovieRequestDto requestDto = new()
        {
            Director = "Serdar Akar",
            Genre = "Action",
            Poster = null,
            Trailer = null,
            Title = "Kurtlar Vadisi Irak",
            Year = "2006",
            Plot = null
        };

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


        // Act
        var addedMovie = await _movieService.AddMovieAsync(movie);

        // Assert
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
}