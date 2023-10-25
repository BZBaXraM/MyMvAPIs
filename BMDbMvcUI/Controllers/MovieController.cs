using BMDbMvcUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BMDbMvcUI.Controllers;

public class MovieController : Controller
{
    private readonly IAsyncMovieService _service;

    public MovieController(IAsyncMovieService asyncMovieService)
        => _service = asyncMovieService;

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return await Task.FromResult<IActionResult>(View(await _service.GetMoviesAsync()));
    }

    public async Task<IActionResult> SearchMoviesAsync()
    {
        return await Task.FromResult<IActionResult>(View());
    }

    [HttpPost]
    public async Task<IActionResult> SearchMoviesAsync(string search)
    {
        return await Task.FromResult<IActionResult>(View("Index", await _service.SearchMoviesAsync(search)));
    }
}