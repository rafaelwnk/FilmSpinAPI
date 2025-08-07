using FilmSpinAPI.Models;

namespace FilmSpinAPI.Interfaces;

public interface ITmdbService
{
    string BuildUrl(FilmRequest filmRequest);
    Task<Film> GetRandomFilmAsync(FilmRequest filmRequest, int page);
    Task<int> GetRandomPageAsync(FilmRequest filmRequest);
    Task<List<Genre>> GetGenresAsync();
}