using BMDb.API.Entities;
using BMDb.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BMDb.API.Services;

/// <summary>
/// This class is used to implement the IAsyncMovieService interface.
/// </summary>
public class MovieService : IAsyncMovieService
{
    private readonly MovieContext _context;

    /// <summary>
    /// This constructor is used to inject the MovieContext class.
    /// </summary>
    /// <param name="context"></param>
    public MovieService(MovieContext context)
        => _context = context;

    /// <summary>
    /// This method is used to get all movies.
    /// </summary>
    /// <returns></returns>
    public async Task<List<Movie>> GetMoviesAsync(string? filterOn, string? filterQuery,
        string? sortBy, bool isAscending = true, int pageNumber = 1, int pageSize = 100)
    {
        // Filtering
        switch (string.IsNullOrWhiteSpace(filterOn))
        {
            case false when string.IsNullOrWhiteSpace(filterQuery) == false:
            {
                switch (filterOn)
                {
                    case "title":
                        return await _context.Movies.Where(x => x.Title.Contains(filterQuery)).AsNoTracking()
                            .ToListAsync();
                    case "year":
                        return await _context.Movies.Where(x => x.Year.Contains(filterQuery)).AsNoTracking()
                            .ToListAsync();
                    case "director":
                        return await _context.Movies.Where(x => x.Director.Contains(filterQuery)).AsNoTracking()
                            .ToListAsync();
                    case "genre":
                        return await _context.Movies.Where(x => x.Genre.Contains(filterQuery)).AsNoTracking()
                            .ToListAsync();
                }

                break;
            }
        }

        // Sorting
        switch (string.IsNullOrWhiteSpace(sortBy))
        {
            case false:
            {
                switch (sortBy)
                {
                    case "title":
                        return isAscending
                            ? await _context.Movies.OrderBy(x => x.Title).AsNoTracking().ToListAsync()
                            : await _context.Movies.OrderByDescending(x => x.Title).AsNoTracking().ToListAsync();
                    case "year":
                        return isAscending
                            ? await _context.Movies.OrderBy(x => x.Year).AsNoTracking().ToListAsync()
                            : await _context.Movies.OrderByDescending(x => x.Year).AsNoTracking().ToListAsync();
                    case "director":
                        return isAscending
                            ? await _context.Movies.OrderBy(x => x.Director).AsNoTracking().ToListAsync()
                            : await _context.Movies.OrderByDescending(x => x.Director).AsNoTracking().ToListAsync();
                    case "genre":
                        return isAscending
                            ? await _context.Movies.OrderBy(x => x.Genre).AsNoTracking().ToListAsync()
                            : await _context.Movies.OrderByDescending(x => x.Genre).AsNoTracking().ToListAsync();
                }

                break;
            }
        }

        // Pagination
        var skip = (pageNumber - 1) * pageSize;

        return await _context.Movies.Skip(skip).Take(pageSize).AsNoTracking().ToListAsync();
    }

    /// <summary>
    /// This method is used to get a movie by id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Movie?> GetMovieByIdAsync(Guid id)
    {
        var item = await _context.Movies.FindAsync(id);
        return new Movie
        {
            Id = item!.Id,
            Title = item.Title,
            Year = item.Year,
            Director = item.Director,
            Genre = item.Genre,
            Plot = item.Plot,
            Poster = item.Poster,
            Trailer = item.Trailer,
            ImdbId = item.ImdbId
        };
    }

    /// <summary>
    /// This method is used to add a movie.
    /// </summary>
    /// <param name="movie"></param>
    /// <returns></returns>
    public async Task<Movie> AddMovieAsync(Movie movie)
    {
        await _context.Movies.AddAsync(movie);
        await _context.SaveChangesAsync();

        return movie;
    }

    /// <summary>
    /// This method is used to update a movie.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="movie"></param>
    /// <returns></returns>
    public async Task<Movie?> UpdateMovieAsync(Guid id, Movie movie)
    {
        var update = await _context.Movies.FirstOrDefaultAsync(x => x.Id == id);
        if (update is null)
        {
            return null;
        }

        update.Title = movie.Title;
        update.Year = movie.Year;
        movie.Director = movie.Director;
        update.Genre = movie.Genre;
        update.Plot = movie.Plot;
        update.Poster = movie.Poster;
        update.Trailer = movie.Trailer;
        update.ImdbId = movie.ImdbId;
        await _context.SaveChangesAsync();

        return movie;
    }

    /// <summary>
    /// This method is used to delete a movie.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Movie> DeleteMovieAsync(Guid id)
    {
        var item = await _context.Movies.FindAsync(id);
        if (item is null) return null!;
        _context.Movies.Remove(item);
        await _context.SaveChangesAsync();

        return item;
    }

    /// <summary>
    /// This method is used to get a movie by title.
    /// </summary>
    /// <param name="title"></param>
    /// <returns></returns>
    public async Task<List<Movie>> GetMovieByTitleAsync(string title)
        => await _context.Movies.Where(x => x.Title.Contains(title)).AsNoTracking().ToListAsync();


    /// <summary>
    /// This method is used to get a movie by year.
    /// </summary>
    /// <param name="year"></param>
    /// <returns></returns>
    public async Task<IEnumerable<Movie>> GetMovieByYearAsync(string year)
        => await _context.Movies.Where(x => x.Year == year).AsNoTracking().ToListAsync();


    /// <summary>
    /// This method is used to get a movie by director.
    /// </summary>
    /// <param name="director"></param>
    /// <returns></returns>
    public async Task<IEnumerable<Movie>> GetMovieByDirectorAsync(string director)
        => await _context.Movies.Where(x => x.Director == director).AsNoTracking().ToListAsync();


    /// <summary>
    /// This method is used to get a movie by genre.
    /// </summary>
    /// <param name="genre"></param>
    /// <returns></returns>
    public async Task<IEnumerable<Movie>> GetMovieByGenreAsync(string genre)
        => await _context.Movies.Where(x => x.Genre == genre).AsNoTracking().ToListAsync();


    /// <summary>
    /// This method is used to get a movie by imdb id.
    /// </summary>
    /// <param name="imdbId"></param>
    /// <returns></returns>
    public async Task<IEnumerable<Movie>> GetMovieByImdbIdAsync(string imdbId)
        => await _context.Movies.Where(x => x.ImdbId == imdbId).AsNoTracking().ToListAsync();


    /// <summary>
    /// This method is used to get the total count of movies.
    /// </summary>
    /// <returns></returns>
    public Task<int> GetTotalCountAsync()
        => _context.Movies.CountAsync();
}