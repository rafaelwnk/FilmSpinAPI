using System.Net.Http.Headers;
using FilmSpinAPI.Exceptions;
using FilmSpinAPI.Interfaces;
using FilmSpinAPI.Models;

namespace FilmSpinAPI.Services;

public class TmdbService : ITmdbService
{
    private readonly HttpClient _client;
    public string Url { get; set; } = Configuration.Url;
    public string GenreUrl { get; set; } = Configuration.GenreUrl;
    public string TmdbToken { get; set; } = Configuration.TmdbToken;
    public Random Random { get; set; } = new();

    public TmdbService(HttpClient client)
    {
        _client = client;
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TmdbToken);
    }

    public async Task<Film> GetRandomFilmAsync(FilmRequest filmRequest, int page)
    {
        if (string.IsNullOrEmpty(filmRequest.Decade))
        {
            var response = await _client.GetAsync($"{Url}?language=pt-BR&vote_average.gte={filmRequest.Rating}&with_genres={filmRequest.Genre}&vote_count.gte=250&page={page}");
            var data = await response.Content.ReadFromJsonAsync<FilmResponse>();

            if (data == null)
                throw new ApiResponseException();

            if (!data.Results.Any())
                throw new FilmNotFoundException();

            var film = data.Results[Random.Next(data.Results.Count)];
            var allGenres = await GetGenresAsync();
            film.Genres = allGenres.Where(x => film.GenreIds.Contains(x.Id)).ToList();
            return film;
        }
        else
        {
            var response = await _client.GetAsync($"{Url}?language=pt-BR&primary_release_date.gte={int.Parse(filmRequest.Decade)}-01-01&primary_release_date.lte={int.Parse(filmRequest.Decade) + 9}-12-31&vote_average.gte={filmRequest.Rating}&with_genres={filmRequest.Genre}&vote_count.gte=250&page={page}");
            var data = await response.Content.ReadFromJsonAsync<FilmResponse>();

            if (data == null)
                throw new ApiResponseException();

            if (!data.Results.Any())
                throw new FilmNotFoundException();

            var film = data.Results[Random.Next(data.Results.Count)];
            var allGenres = await GetGenresAsync();
            film.Genres = allGenres.Where(x => film.GenreIds.Contains(x.Id)).ToList();
            return film;
        }
    }

    public async Task<int> GetRandomPageAsync(FilmRequest filmRequest)
    {
        if (!string.IsNullOrEmpty(filmRequest.Rating) && !float.TryParse(filmRequest.Rating, out float rating))
            throw new ArgumentException($"'{filmRequest.Rating}' não é um número decimal válido");

        if (string.IsNullOrEmpty(filmRequest.Decade))
        {
            var response = await _client.GetAsync($"{Url}?language=pt-BR&vote_average.gte={filmRequest.Rating}&with_genres={filmRequest.Genre}&vote_count.gte=250");
            var data = await response.Content.ReadFromJsonAsync<FilmResponse>();

            if (data == null)
                throw new ApiResponseException();

            return Random.Next(1, Math.Min(data.TotalPages, 500) + 1);
        }
        else
        {
            if (!string.IsNullOrEmpty(filmRequest.Decade) && !int.TryParse(filmRequest.Decade, out int decade))
                throw new ArgumentException($"'{filmRequest.Decade}' não é um número inteiro válido para ano");

            var response = await _client.GetAsync($"{Url}?language=pt-BR&primary_release_date.gte={int.Parse(filmRequest.Decade)}-01-01&primary_release_date.lte={int.Parse(filmRequest.Decade) + 9}-12-31&vote_average.gte={filmRequest.Rating}&with_genres={filmRequest.Genre}&vote_count.gte=250");
            var data = await response.Content.ReadFromJsonAsync<FilmResponse>();

            if (data == null)
                throw new ApiResponseException();

            return Random.Next(1, Math.Min(data.TotalPages, 500) + 1);
        }
    }

    public async Task<List<Genre>> GetGenresAsync()
    {
        var response = await _client.GetAsync(GenreUrl);
        var data = await response.Content.ReadFromJsonAsync<GenreResponse>();

        if (data == null)
            throw new ApiResponseException();

        if (!data.Genres.Any())
            throw new GenresNotFoundException();

        var genres = data!.Genres;
        return genres;
    }
}