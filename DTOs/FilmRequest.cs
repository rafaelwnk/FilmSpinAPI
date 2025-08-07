namespace FilmSpinAPI.DTOs;

public record FilmRequest(string Genre, string Decade, string Rating)
{
    public (bool IsValid, string? Message) IsValid()
    {
        if (!string.IsNullOrEmpty(Decade) && !int.TryParse(Decade, out _))
            return (false, $"'{Decade}' não é um número inteiro válido para ano");

        if (!string.IsNullOrEmpty(Rating) && !float.TryParse(Rating, out _))
            return (false, $"'{Rating}' não é um número decimal válido");

        return (true, null);
    }
};