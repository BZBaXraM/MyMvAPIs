using BMDb.BlazorApp.Models;

namespace BMDb.BlazorApp.Services;

public interface IAsyncAzureMovieService
{
    Task<List<MovieModel>> GetMoviesAsync();
    Task<List<MovieModel>> SearchMoviesAsync(string? search);
    Task<int> GetTotalCountAsync();
}