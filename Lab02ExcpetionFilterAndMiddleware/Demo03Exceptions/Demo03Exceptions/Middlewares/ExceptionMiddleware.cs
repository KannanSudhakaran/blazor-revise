namespace Demo03Exceptions.Middlewares
{
    using Microsoft.AspNetCore.Http;
    using System.Net;
    using System.Threading.Tasks;

    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync($"{{\"error handled in middleware\": \"{ex.Message}\"}}");
                // Optionally log ex here
            }
        }
    }
}
