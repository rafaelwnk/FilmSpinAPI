using System.Text.Json.Serialization;
using FilmSpinAPI.Models;

namespace FilmSpinAPI.Dtos;

public record TmdbGenresResponse
(
    [property: JsonPropertyName("genres")] List<Genre> Genres
);