using FilmSpinAPI.Dtos;
using FilmSpinAPI.Models;

namespace FilmSpinAPI.Extensions;

public static class FilmExtensions
{
    public static FilmResponse MapToFilmResponse(this Film film, string posterUrl)
        => new FilmResponse
        (
            film.Id,
            film.Title,
            film.Genres,
            film.Overview,
            posterUrl + film.PosterPath,
            film.ReleaseDate.Substring(0, 4),
            Math.Round(film.VoteAverage, 1)
        );
}