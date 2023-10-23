using System.ComponentModel.DataAnnotations;

namespace BMDbAPI.DTOs;

/// <summary>
/// This class is used to define the AddMovieRequestDto class.
/// </summary>
public class AddMovieRequestDto
{
    /// <summary>
    /// This property is used to define the Title property.
    /// </summary>
   
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// This property is used to define the Poster property.
    /// </summary>
    public string? Poster { get; set; }

    /// <summary>
    /// This property is used to define the Year property.
    /// </summary>
  
    public string Year { get; set; } = string.Empty;

    /// <summary>
    /// This property is used to define the Director property.
    /// </summary>
   
    public string Director { get; set; } = string.Empty;

    /// <summary>
    /// This property is used to define the Genre property.
    /// </summary>
   
    public string Genre { get; set; } = string.Empty;
}