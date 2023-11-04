using BMDb.BlazorApp.Models;

namespace BMDb.BlazorApp.Services;

public class MovieService : IAsyncMovieService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly List<Movie> _movies = new();

    public MovieService(IHttpClientFactory httpClientFactory)
        => _httpClientFactory = httpClientFactory;

    public async Task<List<Movie>> GetMoviesAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var message = await client.GetAsync("https://localhost:7212/api/movie");
        message.EnsureSuccessStatusCode();
        _movies.AddRange((await message.Content.ReadFromJsonAsync<IEnumerable<Movie>>())!);

        return _movies;
    }

    public async Task<List<Movie>> SearchMoviesAsync(string? search)
    {
        var client = _httpClientFactory.CreateClient();
        if (search is null) return _movies;
        var response =
            await client.GetAsync($"https://localhost:7212/api/Movie/title/{Uri.EscapeDataString(search)}");
        response.EnsureSuccessStatusCode();
        _movies.AddRange((await response.Content.ReadFromJsonAsync<IEnumerable<Movie>>())!);

        return _movies;
    }
}