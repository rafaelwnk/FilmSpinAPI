using System.Text.Json.Serialization;

namespace FilmSpinAPI.Models;

public class Film
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("genre_ids")]
    public List<int> GenreIds { get; set; } = new();
    public List<Genre> Genres { get; set; } = new();

    [JsonPropertyName("overview")]
    public string Overview { get; set; } = string.Empty;

    [JsonPropertyName("poster_path")]
    public string PosterPath { get; set; } = string.Empty;

    [JsonPropertyName("release_date")]
    public string ReleaseDate { get; set; } = string.Empty;

    [JsonPropertyName("vote_average")]
    public float VoteAverage { get; set; }
}