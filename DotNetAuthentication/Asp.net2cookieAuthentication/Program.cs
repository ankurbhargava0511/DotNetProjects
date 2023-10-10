

using Asp.net2_cookieAuthentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAuthentication(AuthSchemes.AuthScheme0)
    .AddCookie(AuthSchemes.AuthScheme0)
    .AddCookie(AuthSchemes.AuthScheme1);

builder.Services.AddAuthorization(builder =>
{
    // use can also add useauthentication handler
    builder.AddPolicy("app", pb =>
    {
        pb.RequireAuthenticatedUser()
        .AddAuthenticationSchemes(AuthSchemes.AuthScheme0)
        .RequireClaim("app-type","app-user");
    });

    builder.AddPolicy("emp", pb =>
    {
        pb.RequireAuthenticatedUser()
        .AddAuthenticationSchemes(AuthSchemes.AuthScheme1)
        .RequireClaim("emp-type","emp-user");
    });

    builder.AddPolicy("admin", pb =>
    {
        pb.RequireAuthenticatedUser()
        .AddAuthenticationSchemes(AuthSchemes.AuthScheme1)
        .RequireClaim("admin-type","admin-user");
    });

});


var app = builder.Build();



app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
