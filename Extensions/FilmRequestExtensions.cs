using FilmSpinAPI.Dtos;

namespace FilmSpinAPI.Extensions;

public static class FilmRequestExtensions
{
    public static (bool IsValid, string? Message) IsValid(this FilmRequest filmRequest)
    {
        if (!string.IsNullOrEmpty(filmRequest.Decade) && !int.TryParse(filmRequest.Decade, out _))
            return (false, $"'{filmRequest.Decade}' não é um número inteiro válido para ano");

        if (!string.IsNullOrEmpty(filmRequest.Rating) && !float.TryParse(filmRequest.Rating, out _))
            return (false, $"'{filmRequest.Rating}' não é um número decimal válido");

        return (true, null);
    }
}