using Basic6LogAndFilter.Filter.ActionFilters;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers(Options =>
{
    var logger= builder.Services.BuildServiceProvider().GetRequiredService<ILogger<MyActionFilterMethodGlobal>>();

    Options.Filters.Add( new MyActionFilterMethodGlobal(logger));
});

builder.Services.AddHttpClient();

builder.Host.ConfigureLogging(loggingProvider =>
{
    loggingProvider.ClearProviders();
    loggingProvider.AddConsole();
    loggingProvider.AddDebug();
    //loggingProvider.AddEventLog();
});

builder.Services.AddHttpLogging(option => {
    option.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.All;
});

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
};

app.Logger.LogDebug("Debug");
app.Logger.LogInformation("Info");
app.Logger.LogWarning("Warning");
app.Logger.LogError("Error");
app.Logger.LogCritical("Critical");
app.UseHttpLogging(); // Provide HTTP Request

app.Run();