using System.Net.Http.Headers;
using BMDb.MVC.Models;

namespace BMDb.MVC.Services;

public class MovieService : IAsyncMovieService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IAsyncJwtService _jwtService;
    private readonly List<MovieViewModel> _movies = new();

    public MovieService(IHttpClientFactory httpClientFactory, IAsyncJwtService jwtService)
    {
        _httpClientFactory = httpClientFactory;
        _jwtService = jwtService;
    }

    public async Task<List<MovieViewModel>> GetMoviesAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var token = await _jwtService.GetAccessTokenAsync();
        client.DefaultRequestHeaders.Authorization = new("Bearer", token);
        var message = await client.GetAsync("https://localhost:7212/api/movie");

        message.EnsureSuccessStatusCode();
        _movies.AddRange((await message.Content.ReadFromJsonAsync<IEnumerable<MovieViewModel>>())!);

        return _movies;
    }

    public async Task<List<MovieViewModel>> SearchMoviesAsync(string? search)
    {
        var client = _httpClientFactory.CreateClient();
        var token = await _jwtService.GetAccessTokenAsync();
        client.DefaultRequestHeaders.Authorization = new("Bearer", token);
        if (search is null) return _movies;
        var response =
            await client.GetAsync($"https://localhost:7212/api/Movie/title/{Uri.EscapeDataString(search)}");

        response.EnsureSuccessStatusCode();
        _movies.AddRange((await response.Content.ReadFromJsonAsync<IEnumerable<MovieViewModel>>())!);

        return _movies;
    }
}