using Basic4ServicesDI.AllServices;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddTransient<IPersons, Persons>();
builder.Services.AddTransient<ITrans, Tansgi>();
builder.Services.AddScoped<IScoped, Scopes>();
builder.Services.AddSingleton<ISingle, Singlett>();


var app = builder.Build();


app.UseStaticFiles();
app.UseRouting();
app.MapControllers();



app.Run();
