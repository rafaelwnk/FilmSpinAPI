using FilmSpinAPI.Endpoints;
using FilmSpinAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.LoadConfiguration();
builder.AddServices();

var app = builder.Build();
app.MapFilmEndpoints();
app.MapHealthChecks("/health");

app.Run();