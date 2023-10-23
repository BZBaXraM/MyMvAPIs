using System.Text;
using System.Text.Json;
using BMDbMvcUI.Models;

namespace BMDbMvcUI.Services;

public class EditorService : IAsyncEditorService
{
    private readonly IHttpClientFactory _client;

    public EditorService(IHttpClientFactory client)
    {
        _client = client;
    }

    public async Task<MovieViewModel> AddMovieAsync(AddMovieViewModel model)
    {
        var client = _client.CreateClient();
        HttpRequestMessage requestMessage = new()
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri("https://localhost:7212/api/movie"),
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
        HttpRequestMessage requestMessage = new()
        {
            Method = HttpMethod.Put,
            RequestUri = new Uri($"https://localhost:7212/api/movie/{model.Id}"),
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
        var response =
            await client.GetFromJsonAsync<MovieViewModel>($"https://localhost:7212/api/movie/{id.ToString()}");

        return response!;
    }

    public async Task<MovieViewModel> DeleteMovieByIdAsync(MovieViewModel model)
    {
        var client = _client.CreateClient();
        HttpRequestMessage requestMessage = new()
        {
            Method = HttpMethod.Delete,
            RequestUri = new Uri($"https://localhost:7212/api/movie/{model.Id}"),
            Content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json")
        };

        var message = await client.SendAsync(requestMessage);
        message.EnsureSuccessStatusCode();
        var response = await message.Content.ReadFromJsonAsync<MovieViewModel>();

        return response!;
    }
}