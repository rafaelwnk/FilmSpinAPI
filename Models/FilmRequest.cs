namespace FilmSpinAPI.Models;

public class FilmRequest
{
    public string Genre { get; set; } = string.Empty;
    public string Decade { get; set; } = string.Empty;
    public string Rating { get; set; } = string.Empty;
}