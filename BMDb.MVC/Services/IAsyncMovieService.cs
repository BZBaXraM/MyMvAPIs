using BMDb.MVC.Models;

namespace BMDb.MVC.Services;

public interface IAsyncMovieService
{
    Task<List<MovieViewModel>> GetMoviesAsync();
    Task<List<MovieViewModel>> SearchMoviesAsync(string? search);
}