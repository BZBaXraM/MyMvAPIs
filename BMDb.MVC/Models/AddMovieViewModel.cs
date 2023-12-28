namespace BMDb.MVC.Models;

public class AddMovieViewModel
{
    public string Title { get; set; } = string.Empty;
    public string? Poster { get; set; }
    public string Year { get; set; } = string.Empty;
    public string Director { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public string? Plot { get; set; }
    public string? Trailer { get; set; }
    public string ImdbId { get; set; } = string.Empty;
}