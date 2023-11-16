using System.Text.Json;
using AutoMapper;
using BMDb.API.CustomFilters;
using BMDb.API.Data;
using BMDb.API.DTOs;
using BMDb.API.Models;
using BMDb.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BMDb.API.Controllers;

/// <summary>
/// This class is used to define the MovieController class.
/// </summary>
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class MovieController : ControllerBase
{
    private readonly IAsyncMovieService _service;
    private readonly IMapper _mapper;
    private readonly ILogger<MovieController> _logger;

    /// <summary>
    /// This constructor is used to inject the MovieContext class.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="mapper"></param>
    /// <param name="logger"></param>
    public MovieController(MovieContext context, IMapper mapper, ILogger<MovieController> logger)
    {
        _service = new MovieService(context);
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    /// This method is used to get all movies.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetMoviesAsync([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
        [FromQuery] string? sortBy, [FromQuery] bool? isAscending,
        [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 100)
    {
        _logger.LogInformation("GetMoviesAsync Action Method was invoked");
        _logger.LogWarning("This is a warring log");
        _logger.LogError("This is a error log");
        var movies = await _service.GetMoviesAsync(filterOn, filterQuery, sortBy,
            isAscending ?? true,
            pageNumber,
            pageSize);
        _logger.LogInformation("Finished GetMoviesAsync request with data: {Serialize}",
            JsonSerializer.Serialize(movies));

        return Ok(_mapper.Map<IEnumerable<MovieDto>>(movies));
    }


    /// <summary>
    /// This method is used to get a movie by id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetMovieById([FromRoute] Guid id)
        => Ok(_mapper.Map<MovieDto>(await _service.GetMovieByIdAsync(id)));


    /// <summary>
    /// This method is used to add a movie.
    /// </summary>
    /// <param name="requestDto"></param>
    /// <returns></returns>
    [HttpPost]
    [ValidateModel]
    public async Task<IActionResult> AddMovieAsync([FromBody] AddMovieRequestDto requestDto)
    {
        var movieModel = _mapper.Map<Movie>(requestDto);
        if (movieModel is null)
        {
            return NotFound();
        }

        var movieDto = _mapper.Map<MovieDto>(await _service.AddMovieAsync(movieModel));

        return CreatedAtAction(nameof(GetMovieById), new { id = movieDto.Id }, movieDto);
    }

    /// <summary>
    /// This method is used to update a movie.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut("{id:guid}")]
    [ValidateModel]
    public async Task<IActionResult> UpdateMovieAsync([FromRoute] Guid id, [FromBody] UpdateMovieRequestDto request)
    {
        var movieModel = _mapper.Map<Movie>(request);
        if (movieModel is null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<MovieDto>(await _service.UpdateMovieAsync(id, movieModel)));
    }

    /// <summary>
    /// This method is used to delete a movie.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteMovieAsync([FromRoute] Guid id)
        => Ok(_mapper.Map<MovieDto>(await _service.DeleteMovieAsync(id)));


    /// <summary>
    /// This method is used to get a movie by title.
    /// </summary>
    /// <param name="title"></param>
    /// <returns></returns>
    [HttpGet("title/{title}")]
    public async Task<IActionResult> GetMovieByTitleAsync(string title)
        => Ok(await _service.GetMovieByTitleAsync(title));


    /// <summary>
    /// This method is used to get a movie by year.
    /// </summary>
    /// <param name="year"></param>
    /// <returns></returns>
    [HttpGet("year/{year}")]
    public async Task<IActionResult> GetMovieByYearAsync(string year)
        => Ok(await _service.GetMovieByYearAsync(year));


    /// <summary>
    /// This method is used to get a movie by director.
    /// </summary>
    /// <param name="director"></param>
    /// <returns></returns>
    [HttpGet("director/{director}")]
    public async Task<IActionResult> GetMovieByDirectorAsync(string director)
        => Ok(await _service.GetMovieByDirectorAsync(director));


    /// <summary>
    /// This method is used to get a movie by genre.
    /// </summary>
    /// <param name="genre"></param>
    /// <returns></returns>
    [HttpGet("genre/{genre}")]
    public async Task<IActionResult> GetMovieByGenreAsync(string genre)
        => Ok(await _service.GetMovieByGenreAsync(genre));

    /// <summary>
    /// This method is used to get a movie by imdb id.
    /// </summary>
    /// <param name="imdb"></param>
    /// <returns></returns>
    [HttpGet("imdb/{imdb}")]
    public async Task<IActionResult> GetMovieByImdbIdAsync(string imdb)
        => Ok(await _service.GetMovieByImdbIdAsync(imdb));

    /// <summary>
    /// This method is used to get the total count of movies.
    /// </summary>
    /// <returns></returns>
    [HttpGet("count")]
    public async Task<IActionResult> GetTotalCountAsync()
        => Ok(await _service.GetTotalCountAsync());
}