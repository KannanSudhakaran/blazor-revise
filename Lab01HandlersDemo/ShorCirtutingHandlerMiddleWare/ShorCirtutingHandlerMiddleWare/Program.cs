using ShorCirtutingHandlerMiddleWare;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseMiddleware<ShortCircuitHandlerMiddleware>();
app.MapGet("/", () => "Hello World!");

app.Run();
