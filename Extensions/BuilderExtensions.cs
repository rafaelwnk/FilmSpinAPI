using FilmSpinAPI.Interfaces;
using FilmSpinAPI.Services;

namespace FilmSpinAPI.Extensions;

public static class BuilderExtensions
{
    public static void LoadConfiguration(this WebApplicationBuilder builder)
    {
        Configuration.Url = builder.Configuration.GetValue<string>("Url")!;
        Configuration.GenreUrl = builder.Configuration.GetValue<string>("GenreUrl")!;
        Configuration.PosterUrl = builder.Configuration.GetValue<string>("PosterUrl")!;
        Configuration.TmdbToken = builder.Configuration.GetValue<string>("TmdbToken")!;
    }

    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddHttpClient();
        builder.Services.AddScoped<ITmdbService, TmdbService>();
        builder.Services.AddHealthChecks();
    }
}