using System.Net.Http.Headers;
using FilmSpinAPI.Interfaces;
using FilmSpinAPI.Models;

namespace FilmSpinAPI.Services;

public class TmdbService : ITmdbService
{
    private readonly HttpClient _client;
    public string Url { get; set; } = "https://api.themoviedb.org/3/discover/movie";
    public string GenreUrl { get; set; } = "https://api.themoviedb.org/3/genre/movie/list?language=pt-BR";
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
            var response = await _client.GetAsync($"{Url}?language=pt-BR&vote_average.gte={filmRequest.Rating}&with_genres={filmRequest.Genre}&vote_count.gte=250");
            var data = await response.Content.ReadFromJsonAsync<FilmResponse>();
            var film = data!.Results[Random.Next(data.Results.Count)];
            var allGenres = await GetGenresAsync();
            film.Genres = allGenres.Where(x => film.GenreIds.Contains(x.Id)).ToList();
            return film;
        }
        else
        {
            var response = await _client.GetAsync($"{Url}?language=pt-BR&primary_release_date.gte={int.Parse(filmRequest.Decade)}-01-01&primary_release_date.lte={int.Parse(filmRequest.Decade) + 9}-12-31&vote_average.gte={filmRequest.Rating}&with_genres={filmRequest.Genre}&vote_count.gte=250");
            var data = await response.Content.ReadFromJsonAsync<FilmResponse>();
            var film = data!.Results[Random.Next(data.Results.Count)];
            var allGenres = await GetGenresAsync();
            film.Genres = allGenres.Where(x => film.GenreIds.Contains(x.Id)).ToList();
            return film;
        }
    }

    public async Task<int> GetRandomPageAsync(FilmRequest filmRequest)
    {
        if (string.IsNullOrEmpty(filmRequest.Decade))
        {
            var response = await _client.GetAsync($"{Url}?language=pt-BR&vote_average.gte={filmRequest.Rating}&with_genres={filmRequest.Genre}&vote_count.gte=250");
            var data = await response.Content.ReadFromJsonAsync<FilmResponse>();
            return Random.Next(1, data!.TotalPages + 1);
        }
        else
        {
            var response = await _client.GetAsync($"{Url}?language=pt-BR&primary_release_date.gte={int.Parse(filmRequest.Decade)}-01-01&primary_release_date.lte={int.Parse(filmRequest.Decade) + 9}-12-31&vote_average.gte={filmRequest.Rating}&with_genres={filmRequest.Genre}&vote_count.gte=250");
            var data = await response.Content.ReadFromJsonAsync<FilmResponse>();
            return Random.Next(1, data!.TotalPages + 1);
        }
    }

    public async Task<List<Genre>> GetGenresAsync()
    {
        var response = await _client.GetAsync(GenreUrl);
        var data = await response.Content.ReadFromJsonAsync<GenreResponse>();
        var genres = data!.Genres;
        return genres;
    }
}