using System.Text.Json.Serialization;

namespace FilmSpinAPI.Models;

public class FilmResponse
{
    [JsonPropertyName("page")]
    public int Page { get; set; }

    [JsonPropertyName("results")]
    public List<Film> Results { get; set; } = new();

    [JsonPropertyName("total_pages")]
    public int TotalPages { get; set; }
    
    [JsonPropertyName("total_results")]
    public int TotalResults { get; set; }
}