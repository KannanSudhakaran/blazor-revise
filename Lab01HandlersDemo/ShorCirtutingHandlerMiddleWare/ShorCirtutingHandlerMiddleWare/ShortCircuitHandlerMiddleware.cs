namespace ShorCirtutingHandlerMiddleWare
{
    public class ShortCircuitHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ShortCircuitHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/api/special"))
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("Forbidden");
                return; // Short-circuit the pipeline
            }

            await _next(context);
        }
    }
}
