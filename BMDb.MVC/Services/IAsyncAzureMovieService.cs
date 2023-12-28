using BMDb.MVC.Models;

namespace BMDb.MVC.Services;

public interface IAsyncAzureMovieService
{
    Task<List<MovieViewModel>> GetMoviesAsync();
    Task<List<MovieViewModel>> SearchMoviesAsync(string? search);
    Task<MovieViewModel> GetMoviesDetailsAsync(Guid id);
}