using FilmSpinAPI.Models;

namespace FilmSpinAPI.Interfaces;

public interface ITmdbService
{
    Task<Film> GetRandomFilmAsync(FilmRequest filmRequest, int page);
    Task<int> GetPagesAsync(FilmRequest filmRequest);
    Task<List<Genre>> GetGenresAsync();
}