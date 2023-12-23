using System.Text;
using System.Text.Json;
using BMDb.MVC.Models;

namespace BMDb.MVC.Services;

public class EditorService : IAsyncEditorService
{
    private readonly IHttpClientFactory _client;
    private readonly IAsyncJwtService _jwtService;

    public EditorService(IHttpClientFactory client, IAsyncJwtService jwtService)
    {
        _client = client;
        _jwtService = jwtService;
    }

    public async Task<MovieViewModel> AddMovieAsync(AddMovieViewModel model)
    {
        var client = _client.CreateClient();
        var token = await _jwtService.GetAccessTokenAsync();
        client.DefaultRequestHeaders.Authorization = new("Bearer", token);
        HttpRequestMessage requestMessage = new()
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri("https://localhost:7212/api/movie"),
            // RequestUri = new Uri("https://bmdb.azurewebsites.net/api/Movie"),
            Content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json")
        };

        var message = await client.SendAsync(requestMessage);
        message.EnsureSuccessStatusCode();
        var response = await message.Content.ReadFromJsonAsync<MovieViewModel>();

        return response!;
    }

    public async Task<MovieViewModel> EditMovieAsync(MovieViewModel model)
    {
        var client = _client.CreateClient();
        var token = await _jwtService.GetAccessTokenAsync();
        client.DefaultRequestHeaders.Authorization = new("Bearer", token);
        HttpRequestMessage requestMessage = new()
        {
            Method = HttpMethod.Put,
            // RequestUri = new Uri($"https://localhost:7212/api/movie/{model.Id}"),
            RequestUri = new Uri($"https://bmdb.azurewebsites.net/api/Movie/{model.Id}"),
            Content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json")
        };

        var message = await client.SendAsync(requestMessage);
        message.EnsureSuccessStatusCode();
        var response = await message.Content.ReadFromJsonAsync<MovieViewModel>();

        return response!;
    }

    public async Task<MovieViewModel> EditMovieByIdAsync(Guid id)
    {
        var client = _client.CreateClient();
        var token = await _jwtService.GetAccessTokenAsync();
        client.DefaultRequestHeaders.Authorization = new("Bearer", token);
        // var response =
        //     await client.GetFromJsonAsync<MovieViewModel>($"https://localhost:7212/api/movie/{id.ToString()}"); 
        var response =
            await client.GetFromJsonAsync<MovieViewModel>($"https://bmdb.azurewebsites.net/api/Movie/{id.ToString()}");

        return response!;
    }

    public async Task<MovieViewModel> DeleteMovieByIdAsync(MovieViewModel model)
    {
        var client = _client.CreateClient();
        var token = await _jwtService.GetAccessTokenAsync();
        client.DefaultRequestHeaders.Authorization = new("Bearer", token);
        HttpRequestMessage requestMessage = new()
        {
            Method = HttpMethod.Delete,
            // RequestUri = new Uri($"https://localhost:7212/api/movie/{model.Id}"),
            RequestUri = new Uri($"https://bmdb.azurewebsites.net/api/Movie/{model.Id}"),
            Content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json")
        };

        var message = await client.SendAsync(requestMessage);
        message.EnsureSuccessStatusCode();
        var response = await message.Content.ReadFromJsonAsync<MovieViewModel>();

        return response!;
    }

    public async Task<List<MovieViewModel>> GetMoviesAsync()
    {
        var client = _client.CreateClient();
        var token = await _jwtService.GetAccessTokenAsync();
        client.DefaultRequestHeaders.Authorization = new("Bearer", token);
        // var response = await client.GetFromJsonAsync<List<MovieViewModel>>("https://localhost:7212/api/movie");
        var response = await client.GetFromJsonAsync<List<MovieViewModel>>("https://bmdb.azurewebsites.net/api/Movie");

        return response!;
    }
}