using System.Net;
using System.Text.Json;

namespace BlogPessoal.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate Next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        Next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await Next(context);
        }
        catch (Exception e)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var response = new
            {
                statusCode = context.Response.StatusCode,
                message = "Erro interno de servidor",
                detalhe = e.Message
            };

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
