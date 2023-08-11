using LearningSomething.Middlewares;
using System.Runtime.InteropServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<CustomMiddleware>();
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.Use(async  (HttpContext context, RequestDelegate next) =>
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

