using FilmSpinAPI.DTOs;
using FilmSpinAPI.Exceptions;
using FilmSpinAPI.Extensions;
using FilmSpinAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FilmSpinAPI.Endpoints;

public static class FilmEndpoints
{
    public static void MapFilmEndpoints(this WebApplication app)
    {
        app.MapPost("/v1/films", async ([FromBody] FilmRequest filmRequest, ITmdbService tmdbService) =>
        {
            try
            {
                if (filmRequest.IsValid() is (false, var message))
                    return filmRequest.ToBadRequestResult(message!);

                var film = await tmdbService.GetRandomFilmAsync(filmRequest);
                return film.ToOkOrNotFoundResult("Nenhum filme encontrado");
            }
            catch (ApiResponseException e)
            {
                return e.ToFallbackResponse(e.Message);
            }
        });

        app.MapGet("/v1/genres", async (ITmdbService tmdbService) =>
        {
            try
            {
                var genres = await tmdbService.GetGenresAsync();
                return genres.ToOkOrNotFoundResult("Nenhum gênero encontrado");
            }
            catch (ApiResponseException e)
            {
                return e.ToFallbackResponse(e.Message);
            }
        });
    }
}