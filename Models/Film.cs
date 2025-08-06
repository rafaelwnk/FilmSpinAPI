namespace FilmSpinAPI.Models;

public class Film
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public List<Genre> Genres { get; set; } = new();
    public string Overview { get; set; } = string.Empty;
    public string PosterPath { get; set; } = string.Empty;
    public string ReleaseDate { get; set; } = string.Empty;
    public int VoteAverage { get; set; }
}