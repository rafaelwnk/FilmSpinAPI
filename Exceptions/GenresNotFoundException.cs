namespace FilmSpinAPI.Exceptions;

public class GenresNotFoundException : Exception
{
    public GenresNotFoundException() : base("Nenhum gênero encontrado") { }
}