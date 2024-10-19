using Tempo_Shared.Exeption;

namespace Tempo_API.Middleware;

public class ExeptionHandlerMiddleware
{
    private readonly RequestDelegate next;

    public ExeptionHandlerMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (Exception ex)
        {
            await HandleException(context, ex);
        }
    }

    private static async Task HandleException(HttpContext context, Exception exception)
    {
        switch (exception)
        {
            case NotFoundException ex:
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsync(ex.Message);
                break;
            case BadRequestException ex:
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync(ex.Message);
                break;
            default:
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync("Internal Server Error. Please contact the administrator.");
                break;
        }
    }
}
