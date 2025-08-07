namespace FilmSpinAPI.Exceptions;

public class FilmNotFoundException : Exception
{
    public FilmNotFoundException() : base("Nenhum filme encontrado") { }
}