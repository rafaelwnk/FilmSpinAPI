namespace FilmSpinAPI.Exceptions;

public class ApiResponseException : Exception
{
    public ApiResponseException() : base("Falha ao obter dados") { }
}