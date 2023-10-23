using AutoMapper;
using BMDbAPI.DTOs;
using BMDbAPI.Models;

namespace BMDbAPI.Mappings;

/// <inheritdoc />
public class AutoMapperProfiles : Profile
{
    /// <inheritdoc />
    public AutoMapperProfiles()
    {
        CreateMap<MovieDto, Movie>().ReverseMap();
        CreateMap<AddMovieRequestDto, Movie>().ReverseMap();
        CreateMap<UpdateMovieRequestDto, Movie>().ReverseMap();
    }
}