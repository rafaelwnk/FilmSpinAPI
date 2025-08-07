using FilmSpinAPI.DTOs;
using FilmSpinAPI.Models;

namespace FilmSpinAPI.Interfaces;

public interface ITmdbService
{
    Task<Film?> GetRandomFilmAsync(FilmRequest filmRequest);
    Task<List<Genre>?> GetGenresAsync();
}