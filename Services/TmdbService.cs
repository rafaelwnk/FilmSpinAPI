using System.Net.Http.Headers;
using FilmSpinAPI.Dtos;
using FilmSpinAPI.Exceptions;
using FilmSpinAPI.Extensions;
using FilmSpinAPI.Interfaces;
using FilmSpinAPI.Models;

namespace FilmSpinAPI.Services;

public class TmdbService : ITmdbService
{
    private readonly HttpClient _client;
    public string Url { get; init; } = Configuration.Url;
    public string GenreUrl { get; init; } = Configuration.GenreUrl;
    public string PosterUrl { get; init; } = Configuration.PosterUrl;
    public string TmdbToken { get; init; } = Configuration.TmdbToken;
    public Random Random { get; private set; } = new();

    public TmdbService(HttpClient client)
    {
        _client = client;
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TmdbToken);
    }

    private string BuildUrl(FilmRequest filmRequest)
    {
        if (string.IsNullOrEmpty(filmRequest.Decade))
            return $"{Url}?language=pt-BR&vote_average.gte={filmRequest.Rating}&with_genres={filmRequest.Genre}&vote_count.gte=250";

        return $"{Url}?language=pt-BR&primary_release_date.gte={int.Parse(filmRequest.Decade)}-01-01&primary_release_date.lte={int.Parse(filmRequest.Decade) + 9}-12-31&vote_average.gte={filmRequest.Rating}&with_genres={filmRequest.Genre}&vote_count.gte=250";
    }

    private async Task<int> GetRandomPageAsync(FilmRequest filmRequest)
    {
        var response = await _client.GetAsync(BuildUrl(filmRequest));
        var data = await response.Content.ReadFromJsonAsync<TmdbFilmResponse>();

        if (data == null)
            throw new ApiResponseException();

        return Random.Next(1, Math.Min(data.TotalPages, 500) + 1);
    }

    public async Task<FilmResponse?> GetRandomFilmAsync(FilmRequest filmRequest)
    {
        var page = await GetRandomPageAsync(filmRequest);
        var response = await _client.GetAsync($"{BuildUrl(filmRequest)}&page={page}");
        var data = await response.Content.ReadFromJsonAsync<TmdbFilmResponse>();

        if (data == null)
            throw new ApiResponseException();

        if (!data.Results.Any())
            return null;

        var film = data.Results[Random.Next(data.Results.Count)];
        var allGenres = await GetGenresAsync();

        if (allGenres != null)
            film.Genres = allGenres.Where(x => film.GenreIds.Contains(x.Id)).ToList();

        film.PosterPath = PosterUrl + film.PosterPath;
        film.ReleaseDate = film.ReleaseDate.Substring(0, 4);
        film.VoteAverage = Math.Round(film.VoteAverage, 1);

        return film.MapToFilmResponse();
    }

    public async Task<List<Genre>?> GetGenresAsync()
    {
        var response = await _client.GetAsync(GenreUrl);
        var data = await response.Content.ReadFromJsonAsync<TmdbGenresResponse>();

        if (data == null)
            throw new ApiResponseException();

        if (!data.Genres.Any())
            return null;

        var genres = data!.Genres;
        return genres;
    }
}