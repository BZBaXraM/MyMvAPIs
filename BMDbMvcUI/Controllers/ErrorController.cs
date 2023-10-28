// using BMDbMvcUI.Models;
// using Microsoft.AspNetCore.Mvc;
//
// namespace BMDbMvcUI.Controllers;
//
// public class ErrorController : Controller
// {
//     [Route("NotFound")]
//     public async Task<IActionResult> MovieNotFound()
//     {
//         MovieViewModel model = new()
//         {
//             Title = "Movie not found",
//         };
//
//         return await Task.FromResult<IActionResult>(View("MovieNotFound", model));
//     }
// }