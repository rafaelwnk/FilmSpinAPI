using System.Text.Json.Serialization;
using FilmSpinAPI.Models;

namespace FilmSpinAPI.DTOs;

public record GenreResponse
(
    [property: JsonPropertyName("genres")] List<Genre> Genres
);