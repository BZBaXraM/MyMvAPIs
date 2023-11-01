using BMDbMvcUI.Data.Roles;
using BMDbMvcUI.Models;
using BMDbMvcUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BMDbMvcUI.Controllers;

[Authorize(Roles = Roles.Admin)]
public class EditorController : Controller
{
    private readonly IAsyncEditorService _service;

    public EditorController(IAsyncEditorService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        return await Task.FromResult<IActionResult>(RedirectToAction("Index", "Movie"));
    }

    [HttpGet]
    public async Task<IActionResult> Add()
    {
        return await Task.FromResult<IActionResult>(View());
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddMovieViewModel model)
    {
        await _service.AddMovieAsync(model);

        return RedirectToAction("Index", "Movie");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(Guid id)
    {
        var response = await _service.EditMovieByIdAsync(id);

        return View(response);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(MovieViewModel movieViewModel)
    {
        await _service.EditMovieAsync(movieViewModel);

        return RedirectToAction("Index", "Movie");
    }

    [HttpPost]
    public async Task<IActionResult> Delete(MovieViewModel movieViewModel)
    {
        await _service.DeleteMovieByIdAsync(movieViewModel);

        return RedirectToAction("Index", "Movie");
    }

    public async Task<IActionResult> MovieDatabase(int page = 1, int pageSize = 10)
    {
        var movies = await _service.GetMoviesAsync();
        var count = movies.Count;
        var data = movies.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        var viewModel = new PaginationViewModel<MovieViewModel>(data, page, pageSize, count);


        return View(viewModel);
    }
}