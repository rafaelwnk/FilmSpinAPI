using System.Text.Json.Serialization;

namespace FilmSpinAPI.Models;

public class GenreResponse
{
    [JsonPropertyName("genres")]
    public List<Genre> Genres { get; set; } = new();
} 