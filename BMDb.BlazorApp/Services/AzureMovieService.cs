using BMDb.BlazorApp.Models;

namespace BMDb.BlazorApp.Services;

public class AzureMovieService : IAsyncAzureMovieService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IAsyncAzureJwtService _jwtService;
    private readonly List<MovieModel> _movies = new();

    public AzureMovieService(IHttpClientFactory httpClientFactory, IAsyncAzureJwtService jwtService)
    {
        _httpClientFactory = httpClientFactory;
        _jwtService = jwtService;
    }

    public async Task<List<MovieModel>> GetMoviesAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var token = await _jwtService.GetAccessTokenAsync();
        client.DefaultRequestHeaders.Authorization = new("Bearer", token);
        var message = await client.GetAsync("https://bmdb.azurewebsites.net/api/Movie");
        message.EnsureSuccessStatusCode();
        _movies.Clear();

        _movies.AddRange((await message.Content.ReadFromJsonAsync<IEnumerable<MovieModel>>())!);

        return _movies;
    }

    public async Task<List<MovieModel>> SearchMoviesAsync(string? search)
    {
        var client = _httpClientFactory.CreateClient();
        var token = await _jwtService.GetAccessTokenAsync();
        client.DefaultRequestHeaders.Authorization = new("Bearer", token);
        if (search is null)
        {
            return new List<MovieModel>();
        }

        var response =
            await client.GetAsync($"https://bmdb.azurewebsites.net/api/Movie/title/{Uri.EscapeDataString(search)}");
        response.EnsureSuccessStatusCode();

        var searchResults = await response.Content.ReadFromJsonAsync<IEnumerable<MovieModel>>();

        return searchResults?.ToList() ?? new List<MovieModel>();
    }

    public async Task<int> GetTotalCountAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var token = await _jwtService.GetAccessTokenAsync();
        client.DefaultRequestHeaders.Authorization = new("Bearer", token);
        var response = await client.GetAsync("https://bmdb.azurewebsites.net/api/Movie/count");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<int>();
    }
}