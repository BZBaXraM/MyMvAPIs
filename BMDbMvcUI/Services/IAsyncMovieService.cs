using BMDbMvcUI.Models;

namespace BMDbMvcUI.Services;

public interface IAsyncMovieService
{
    Task<List<MovieViewModel>> GetMoviesAsync();
    Task<List<MovieViewModel>> SearchMoviesAsync(string? search);
}