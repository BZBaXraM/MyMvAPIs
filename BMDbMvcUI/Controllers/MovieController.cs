using BMDbMvcUI.Models;
using BMDbMvcUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BMDbMvcUI.Controllers;

public class MovieController : Controller
{
    private readonly IAsyncMovieService _service;

    public MovieController(IAsyncMovieService asyncMovieService)
        => _service = asyncMovieService;

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
    {
        return await Task.FromResult<IActionResult>(View());
    }

    [HttpPost]
    public async Task<IActionResult> SearchMoviesAsync(string search)
    {
        var movies = await _service.SearchMoviesAsync(search);
        var count = movies.Count;
        var data = movies.ToList();

        var viewModel = new PaginationViewModel<MovieViewModel>(data, 1, count, count);

        return View("Index", viewModel);
        // return await Task.FromResult<IActionResult>(View("Index", await _service.SearchMoviesAsync(search)));
    }
}