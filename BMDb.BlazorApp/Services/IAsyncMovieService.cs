using BMDb.BlazorApp.Models;

namespace BMDb.BlazorApp.Services;

public interface IAsyncMovieService
{
    Task<List<Movie>> GetMoviesAsync();
    Task<List<Movie>> SearchMoviesAsync(string? search);
}