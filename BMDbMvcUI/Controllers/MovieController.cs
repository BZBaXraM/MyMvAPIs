using BMDbMvcUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BMDbMvcUI.Controllers;

public class MovieController : Controller
{
    private readonly IAsyncMovieService _service;

    public MovieController(IAsyncMovieService service)
        => _service = service;

    [HttpGet]
    public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
    {
        var movies = await _service.GetMoviesAsync();
        var paginatedMovies = movies.Skip((page - 1) * pageSize).Take(pageSize);
        var totalMovies = movies.Count;

        ViewBag.TotalPages = (int)Math.Ceiling(totalMovies / (double)pageSize);
        ViewBag.CurrentPage = page;

        return View(paginatedMovies);
    }


    [HttpPost]
    public async Task<IActionResult> SearchMoviesAsync(string search, int page = 1, int pageSize = 10)
    {
        if (page <= 0) throw new ArgumentOutOfRangeException(nameof(page));
        var searchResults = await _service.SearchMoviesAsync(search);
        var paginatedSearchResults = searchResults.Skip((page - 1) * pageSize).Take(pageSize);
        var totalResults = searchResults.Count;

        ViewBag.TotalPages = (int)Math.Ceiling(totalResults / (double)pageSize);
        ViewBag.CurrentPage = page;

        return View("Index", paginatedSearchResults);
    }


    [HttpPost]
    public async Task<IActionResult> SearchMoviesAsync(string search)
    {
        return await Task.FromResult<IActionResult>(View("Index", await _service.SearchMoviesAsync(search)));
    }
}