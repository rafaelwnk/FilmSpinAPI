using System.Text.Json.Serialization;
using FilmSpinAPI.Models;

namespace FilmSpinAPI.DTOs;

public record FilmResponse
(
    [property: JsonPropertyName("page")] int Page,
    [property: JsonPropertyName("results")] List<Film> Results,
    [property: JsonPropertyName("total_pages")] int TotalPages,
    [property: JsonPropertyName("total_results")] int TotalResults
);