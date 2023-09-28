using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using WebApiRestWithOpenApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(option =>
{
    option.Filters.Add(new ProducesAttribute("application/json"));
    option.Filters.Add(new ConsumesAttribute("application/json"));
}).AddXmlSerializerFormatters();

builder.Services.AddSingleton<IContactService, ContactService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Discribe all endpoint

//builder.Services.AddSwaggerGen();


builder.Services.AddApiVersioning(config =>
{
    //Route
    config.ApiVersionReader = new UrlSegmentApiVersionReader();
    //Query
    config.ApiVersionReader = new QueryStringApiVersionReader("ver"); // version numbr need to be provided as ver
    config.DefaultApiVersion = new ApiVersion(3, 0);
    config.AssumeDefaultVersionWhenUnspecified = true;
    //Header
    config.ApiVersionReader = new HeaderApiVersionReader("api-version");
});

builder.Services.AddSwaggerGen(option =>
{
    option.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "api.xml"));

    option.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "v1 by Route xml", Version= "1.0" });
    option.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "v2 by Route json", Version = "2.0" });
    option.SwaggerDoc("v3", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "v3 by Query json", Version = "3.0" });
    option.SwaggerDoc("v4", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "v4 by Header json", Version = "4.0" });



});

builder.Services.AddVersionedApiExplorer(options => {
    options.GroupNameFormat = "'v'VVV"; //v1
    options.SubstituteApiVersionInUrl = true;
    
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(option =>
    {
        option.SwaggerEndpoint("/swagger/v1/swagger.json", "1.0");
        option.SwaggerEndpoint("/swagger/v2/swagger.json", "2.0");
        option.SwaggerEndpoint("/swagger/v3/swagger.json", "3.0");
        option.SwaggerEndpoint("/swagger/v4/swagger.json", "4.0");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
