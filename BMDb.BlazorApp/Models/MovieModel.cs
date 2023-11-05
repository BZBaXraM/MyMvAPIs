namespace BMDb.BlazorApp.Models;

public class MovieModel
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Year { get; set; } = string.Empty;
    public string? Poster { get; set; }
    public string Director { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
}