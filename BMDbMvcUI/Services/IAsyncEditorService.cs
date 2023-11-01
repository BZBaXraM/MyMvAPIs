using BMDbMvcUI.Models;

namespace BMDbMvcUI.Services;

public interface IAsyncEditorService
{
    Task<List<MovieViewModel>> GetMoviesAsync();
    Task<MovieViewModel> AddMovieAsync(AddMovieViewModel model);
    Task<MovieViewModel> EditMovieAsync(MovieViewModel model);
    Task<MovieViewModel> EditMovieByIdAsync(Guid id);
    Task<MovieViewModel> DeleteMovieByIdAsync(MovieViewModel model);
}