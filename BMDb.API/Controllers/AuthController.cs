using System.Linq;
using System.Threading.Tasks;
using BMDb.API.DTOs;
using BMDb.API.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BMDb.API.Controllers;

/// <summary>
/// Controller for handling authentication requests.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ITokenService _service;

    /// <summary>
    /// Constructor for injecting UserManager.
    /// </summary>
    /// <param name="userManager"></param>
    /// <param name="service"></param>
    public AuthController(UserManager<IdentityUser> userManager, ITokenService service)
    {
        _userManager = userManager;
        _service = service;
    }

    /// <summary>
    /// Registers a new user.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequestDto request)
    {
        var user = new IdentityUser
        {
            UserName = request.Username,
            Email = request.Username
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (request.Roles.Any())
        {
            result = await _userManager.AddToRolesAsync(user, request.Roles);
        }

        if (result.Succeeded)
        {
            return Ok("User created successfully! Please login.");
        }

        return BadRequest("User creation failed! Please check user details and try again.");
    }

    /// <summary>
    /// Login a user.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginRequestDto request)
    {
        var user = await _userManager.FindByEmailAsync(request.Username);

        if (user is null)
        {
            return BadRequest("Username or password is incorrect!");
        }

        var checkPassword = await _userManager.CheckPasswordAsync(user, request.Password);

        if (!checkPassword)
        {
            return BadRequest("Username or password is incorrect!");
        }

        var roles = await _userManager.GetRolesAsync(user);
        var jwtToken = _service.CreateToken(user, roles.ToList());

        var response = new LoginResponseDto
        {
            JwtToken = jwtToken
        };

        return Ok(response);
    }
}