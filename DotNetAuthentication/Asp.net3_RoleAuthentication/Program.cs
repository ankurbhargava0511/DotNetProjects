using Microsoft.AspNetCore.Mvc;
var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddAuthentication()
//    .AddCookie("cookie");

//builder.Services.AddAuthorization();

//builder.Services.AddDbContext<IdentityDbContext>();


builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
