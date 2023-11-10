using BMDb.MVC.Models;

namespace BMDb.MVC.Services;

public interface IMvcAsyncMovieService
{
    Task<List<MovieViewModel>> GetMoviesAsync();
    Task<List<MovieViewModel>> SearchMoviesAsync(string? search);
}