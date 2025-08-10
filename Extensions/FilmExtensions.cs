using FilmSpinAPI.Dtos;
using FilmSpinAPI.Models;

namespace FilmSpinAPI.Extensions;

public static class FilmExtensions
{
    public static FilmResponse MapToFilmResponse(this Film film)
        => new FilmResponse(film.Id, film.Title, film.Genres, film.Overview, film.PosterPath, film.ReleaseYear, film.VoteAverage);
}