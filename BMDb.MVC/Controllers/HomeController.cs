using Microsoft.AspNetCore.Mvc;

namespace BMDb.MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }


    public async Task<IActionResult> Index()
    {
        return await Task.FromResult(RedirectToAction("SearchMovies", "Movie"));
    }

    public IActionResult Privacy()
    {
        return View();
    }
}