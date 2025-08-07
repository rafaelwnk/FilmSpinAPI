using FilmSpinAPI.Models;

namespace FilmSpinAPI.Extensions;

public static class ResultExtensions
{
    public static IResult ToOkOrNotFoundResult<T>(this T data, string message)
    {
        return data is not null ?
            Results.Ok(ResultData<T>.Success(data)) :
            Results.NotFound(ResultData<T>.Error(message));
    }

    public static IResult ToBadRequestResult<T>(this T data, string message)
        => Results.BadRequest(ResultData<T>.Error(message));

    public static IResult ToFallbackResponse<T>(this T data, string message)
        => Results.Json(ResultData<T>.Error(message), statusCode: 502);
}
