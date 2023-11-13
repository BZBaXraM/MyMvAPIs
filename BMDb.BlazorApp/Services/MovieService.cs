using BMDb.BlazorApp.Models;

namespace BMDb.BlazorApp.Services;

public class MovieService : IAsyncMovieService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly List<MovieModel> _movies = new();

    public MovieService(IHttpClientFactory httpClientFactory)
        => _httpClientFactory = httpClientFactory;

    public async Task<List<MovieModel>> GetMoviesAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var message = await client.GetAsync($"https://localhost:7212/api/Movie");
        message.EnsureSuccessStatusCode();
        _movies.Clear();
        
        _movies.AddRange((await message.Content.ReadFromJsonAsync<IEnumerable<MovieModel>>())!);

        return _movies;
    }

    public async Task<List<MovieModel>> SearchMoviesAsync(string? search)
    {
        var client = _httpClientFactory.CreateClient();
        if (search is null)
        {
            return new List<MovieModel>();
        }

        var response = await client.GetAsync($"https://localhost:7212/api/Movie/title/{Uri.EscapeDataString(search)}");
        response.EnsureSuccessStatusCode();

        var searchResults = await response.Content.ReadFromJsonAsync<IEnumerable<MovieModel>>();

        return searchResults?.ToList() ?? new List<MovieModel>();
    }

    public async Task<int> GetTotalCountAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("https://localhost:7212/api/Movie/count");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<int>();
    }
}