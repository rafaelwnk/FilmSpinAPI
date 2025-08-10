using FilmSpinAPI.Models;

namespace FilmSpinAPI.Dtos;

public record FilmResponse
(
    int Id,
    string Title,
    List<Genre> Genres,
    string Overview,
    string PosterPath,
    string ReleaseYear,
    double VoteAverage
);