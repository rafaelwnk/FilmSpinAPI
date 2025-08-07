using System.Text.Json.Serialization;

namespace FilmSpinAPI.Models;

public class Genre
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
}