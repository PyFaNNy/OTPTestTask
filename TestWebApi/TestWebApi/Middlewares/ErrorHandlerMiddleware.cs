using System.Net;
using System.Text.Json;
using TestWebApi.Application.Exceptions;

namespace TestWebApi.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                Console.Error.WriteLine(error?.Message);
                var response = context.Response;
                response.ContentType = "application/json";
                switch (error)
                {
                    case NotFoundException:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case DeleteEntityException:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        error = new Exception("An error occurred while processing your request.");
                        break;
                }

                var result = JsonSerializer.Serialize(new
                {
                    error?.Message
                });
                await response.WriteAsync(result);
            }
        }
    }
}
