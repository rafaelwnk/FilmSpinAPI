using FilmSpinAPI.Dtos;
using FilmSpinAPI.Models;

namespace FilmSpinAPI.Interfaces;

public interface ITmdbService
{
    Task<FilmResponse?> GetRandomFilmAsync(FilmRequest filmRequest);
    Task<List<Genre>?> GetGenresAsync();
}