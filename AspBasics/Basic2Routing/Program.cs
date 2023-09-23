var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
//Enable Routing
app.UseRouting();

//creating Endpoints
app.UseEndpoints(endpoints =>
{
    // Creating Map 
    endpoints.Map("/Map1", async (context) => {
        await context.Response.WriteAsync("In Map 1");
        });
    endpoints.Map("/Map2", async (context) => {
        await context.Response.WriteAsync("In Map 2");
        });
    endpoints.Map("/Map3", async (context) => {
            await context.Response.WriteAsync("In Map 3");
        });

    endpoints.MapGet("/Map", async (context) => {
        await context.Response.WriteAsync("In Map Get call");
    });

    endpoints.MapPost("/Map", async (context) => {
        await context.Response.WriteAsync("In Map Post call");
    });
    // Route Parameter
    endpoints.Map("/File/{Test}", async (context) => {
        string ? value =Convert.ToString(context.Request.RouteValues["Test"]);
        await context.Response.WriteAsync("Route " + value);
    });
    // Default Route Value
    endpoints.Map("/Employee/{Name=ABC}", async (context) => {
        string? value = Convert.ToString(context.Request.RouteValues["Name"]);
        await context.Response.WriteAsync("Route " + value);
    });


    // Optional Route Value
    endpoints.Map("/Employee1/{Name?}", async (context) => {
        string? value = Convert.ToString(context.Request.RouteValues["Name"]);
        await context.Response.WriteAsync("Route " + value);
    });
});


app.MapGet("/", () => "Hello World!");

app.Run();
