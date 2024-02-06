using BMDb.MVC.Models;
using BMDb.MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace BMDb.MVC.Controllers;

public class MovieController : Controller
{
    private readonly IAsyncMovieService _service;

    public MovieController(IAsyncMovieService service)
        => _service = service;


    [HttpGet]
    public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
    {
        var movies = await _service.GetMoviesAsync();
        var count = movies.Count;
        var data = movies.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        var viewModel = new PaginationViewModel<MovieViewModel>(data, page, pageSize, count);

        return View(viewModel);
    }


    public async Task<IActionResult> SearchMoviesAsync()
        => await Task.FromResult<IActionResult>(View());


    [HttpPost]
    public async Task<IActionResult> SearchMoviesAsync(string? search)
    {
        var movies = await _service.SearchMoviesAsync(search);
        var count = movies.Count;
        var data = movies.ToList();

        var viewModel = new PaginationViewModel<MovieViewModel>(data, 1, 100, count);

        return View("Index", viewModel);
    }

    public async Task<IActionResult> Details(Guid id)
    {
        var movie = await _service.GetMoviesDetailsAsync(id);

        return View(movie);
    }
}