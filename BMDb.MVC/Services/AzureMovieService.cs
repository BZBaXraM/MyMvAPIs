using BMDb.MVC.Models;

namespace BMDb.MVC.Services;

public class AzureMovieService : IAsyncAzureMovieService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IAsyncAzureJwtService _jwtService;
    private readonly List<MovieViewModel> _movies = new();

    public AzureMovieService(IHttpClientFactory httpClientFactory, IAsyncAzureJwtService jwtService)
    {
        _httpClientFactory = httpClientFactory;
        _jwtService = jwtService;
    }

    public async Task<List<MovieViewModel>> GetMoviesAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var token = await _jwtService.GetAccessTokenAsync();
        client.DefaultRequestHeaders.Authorization = new("Bearer", token);
        var message = await client.GetAsync("https://bmdb.azurewebsites.net/api/Movie");
        message.EnsureSuccessStatusCode();
        _movies.Clear();

        _movies.AddRange((await message.Content.ReadFromJsonAsync<IEnumerable<MovieViewModel>>())!);

        return _movies;
    }

    public async Task<List<MovieViewModel>> SearchMoviesAsync(string? search)
    {
        var client = _httpClientFactory.CreateClient();
        var token = await _jwtService.GetAccessTokenAsync();
        client.DefaultRequestHeaders.Authorization = new("Bearer", token);
        if (search is null)
        {
            return new List<MovieViewModel>();
        }

        var response =
            await client.GetAsync($"https://bmdb.azurewebsites.net/api/Movie/title/{Uri.EscapeDataString(search)}");
        response.EnsureSuccessStatusCode();

        var searchResults = await response.Content.ReadFromJsonAsync<IEnumerable<MovieViewModel>>();

        return searchResults?.ToList() ?? new List<MovieViewModel>();
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