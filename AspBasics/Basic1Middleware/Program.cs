using LearningSomething.Middlewares;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions()
{
    WebRootPath = "myroot"
});
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
app.UseStaticFiles();

app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(builder.Environment.ContentRootPath + "\\wwwmyroot")
});

app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("First Middleware");
    await next(context);
});

app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Second  Middleware chain ");
    await next(context);
});

app.UseMiddleware<CustomMiddleware>();
//app.UseCustomMiddlewareExt();
app.UseConvensionalMiddleware();


app.UseWhen(
    context => context.Request.Query.ContainsKey("id"),
    app =>
    {
        // Below Middle where will be executed when contition met
        app.Use(async (HttpContext context, RequestDelegate next) =>
        {
            await context.Response.WriteAsync(" use When ");
            await next(context);
        });
    }
    );
app.Run(async (HttpContext context) =>
{
    //context.Response.StatusCode = 200;
    //context.Response.Headers["TestKey"] = "TestValue";
    //context.Response.Headers["Server"] = "test Server";
    //context.Response.ContentType = "text/plain";

    //var path = context.Request.Path;

    //if (context.Request.Method == "GET")
    //{
    //    if (context.Request.Query.ContainsKey("id"))
    //    {
    //        var query = context.Request.Query["id"];
    //    }

    //}


    //Response= Date/ Server/ 
    await context.Response.WriteAsync("Last Middleware ");
});

app.Run();

