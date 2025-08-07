using FilmSpinAPI.DTOs;
using FilmSpinAPI.Exceptions;
using FilmSpinAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FilmSpinAPI.Endpoints;

public static class FilmEndpoints
{
    public static void MapFilmEndpoints(this WebApplication app)
    {
        app.MapGet("/v1/films", async ([FromBody] FilmRequest filmRequest, ITmdbService tmdbService) =>
        {
            try
            {
                var page = await tmdbService.GetRandomPageAsync(filmRequest);
                var film = await tmdbService.GetRandomFilmAsync(filmRequest, page);
                return Results.Ok(film);
            }
            catch (FilmNotFoundException e)
            {
                return Results.NotFound(new { message = e.Message });
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(new { message = e.Message });
            }
            catch (ApiResponseException e)
            {
                return Results.Problem(
                    title: "Bad Gateway",
                    detail: e.Message,
                    statusCode: StatusCodes.Status502BadGateway
                );
            }
        });

        app.MapGet("/v1/genres", async (ITmdbService tmdbService) =>
        {
            try
            {
                var genres = await tmdbService.GetGenresAsync();
                return Results.Ok(genres);
            }
            catch (GenresNotFoundException e)
            {
                return Results.NotFound(new { message = e.Message });
            }
            catch (ApiResponseException e)
            {
                return Results.Problem(
                    title: "Bad Gateway",
                    detail: e.Message,
                    statusCode: StatusCodes.Status502BadGateway
                );
            }
        });
    }
}