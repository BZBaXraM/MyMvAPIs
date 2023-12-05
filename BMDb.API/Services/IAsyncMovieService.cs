using BMDb.API.Models;

namespace BMDb.API.Services;

/// <summary>
/// This interface is used to define the contract for the AsyncMovieService class.
/// </summary>
public interface IAsyncMovieService
{
    /// <summary>
    /// This method is used to get all movies.
    /// </summary>
    /// <returns> </returns>
    Task<List<Movie>> GetMoviesAsync(string? filterOn, string? filterQuery,
        string? sortBy, bool isAscending = true, int pageNumber = 1, int pageSize = 100);

    /// <summary>
    /// This method is used to get a movie by id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Movie?> GetMovieByIdAsync(Guid id);

    /// <summary>
    /// This method is used to add a movie.
    /// </summary>
    /// <param name="movie"></param>
    /// <returns></returns>
    Task<Movie> AddMovieAsync(Movie movie);

    /// <summary>
    /// This method is used to update a movie.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="movie"></param>
    /// <returns></returns>
    Task<Movie?> UpdateMovieAsync(Guid id, Movie movie);

    /// <summary>
    /// This method is used to delete a movie.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Movie> DeleteMovieAsync(Guid id);

    /// <summary>
    /// This method is used to get a movie by title.
    /// </summary>
    /// <param name="title"></param>
    /// <returns></returns>
    Task<List<Movie>> GetMovieByTitleAsync(string title);

    /// <summary>
    /// This method is used to get a movie by year.
    /// </summary>
    /// <param name="year"></param>
    /// <returns></returns>
    Task<IEnumerable<Movie>> GetMovieByYearAsync(string year);

    /// <summary>
    /// This method is used to get a movie by director.
    /// </summary>
    /// <param name="director"></param>
    /// <returns></returns>
    Task<IEnumerable<Movie>> GetMovieByDirectorAsync(string director);

    /// <summary>
    /// This method is used to get a movie by genre.
    /// </summary>
    /// <param name="genre"></param>
    /// <returns></returns>
    Task<IEnumerable<Movie>> GetMovieByGenreAsync(string genre);

    /// <summary>
    /// This method is used to get a movie by imdb id.
    /// </summary>
    /// <param name="imdbId"></param>
    /// <returns></returns>
    Task<IEnumerable<Movie>> GetMovieByImdbIdAsync(string imdbId);

    /// <summary>
    /// This method is used to get a movie by type.
    /// </summary>
    /// <returns></returns>
    Task<int> GetTotalCountAsync();
}