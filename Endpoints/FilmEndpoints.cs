using FilmSpinAPI.Interfaces;
using FilmSpinAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmSpinAPI.Endpoints;

public static class FilmEndpoints
{
    public static void MapFilmEndpoints(this WebApplication app)
    {
        app.MapGet("/v1/films", async ([FromBody] FilmRequest filmRequest, ITmdbService tmdbService) =>
        {
            var page = await tmdbService.GetRandomPageAsync(filmRequest);
            return await tmdbService.GetRandomFilmAsync(filmRequest, page);
        });

        app.MapGet("/v1/genres", async (ITmdbService tmdbService) =>
        {
            return await tmdbService.GetGenresAsync();
        });
    }
}