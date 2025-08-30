# Hanlder and Modules

[Microsfot official documentation for http hanlders and module](https://learn.microsoft.com/en-us/iis/develop/runtime-extensibility/developing-iis-modules-and-handlers-with-the-net-framework)

## Handlers

Handlers are responsible for handling specific types of requests, such as serving static files or processing dynamic content. Modules, on the other hand, can perform tasks such as authentication, logging, or modifying request and response data.

so, in summary, handlers are focused on the request/response cycle for specific resources, while modules provide a way to extend and customize the behavior of the ASP.NET pipeline as a whole.

If you request ```http://example.com/image.ashx,`` the ImageHandler will be executed.
If you map a custom URL ```(like /api/data) ```to a handler in web.config, requests to that URL will trigger the handler.


```csharp

public class JsonHandler : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        //can add custom logic here

        context.Response.ContentType = "application/json";
        context.Response.Write("{\"status\":\"ok\"}");
    }
    public bool IsReusable => false;// is used for caching
}

```
```xml
<configuration>
  <system.webServer>
    <handlers>
      <add name="JsonHandler" path="*.json" verb="*" type="Namespace.JsonHandler" resourceType="Unspecified" />
    </handlers>
  </system.webServer>
</configuration>
```

### Sample configuration of modules

In the web.xml
```xml
<configuration>
  <system.web>
    <httpModules>
      <add name="MyModule" type="Namespace.MyModule"/>
    </httpModules>
  </system.web>
</configuration>

```
## Modules

HTTP modules are used throughout the entire ASP.NET request pipeline. They are invoked for every request that passes through the application, regardless of the requested resource.

Modules are typically used for:

- Authentication and authorization
- Logging and tracing
- URL rewriting
- Custom headers or response modification
- Session management


# ASP.NET Core Handler Middleware and Module Middleware

Handler middlewares are components that are executed in the request processing pipeline and can handle requests and responses. They are similar to HTTP handlers but are designed to work with the ASP.NET Core middleware pipeline.

Module middlewares, on the other hand, are used to add cross-cutting concerns to the application, such as authentication, logging, and error handling. They can be applied globally or to specific routes.

## Example of a Handler middleware which does shortcircuiting

```csharp
public class ShortCircuitMiddleware
{
    private readonly RequestDelegate _next;

    public ShortCircuitMiddleware(RequestDelegate next)
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
```
## Example of a Module middleware

```csharp
public class MyModuleMiddleware
{
    private readonly RequestDelegate _next;

    public MyModuleMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        // Custom logic before the next middleware
        await _next(context);
        // Custom logic after the next middleware
    }
}
```