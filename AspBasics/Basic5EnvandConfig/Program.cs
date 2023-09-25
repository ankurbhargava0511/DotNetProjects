using Basic5EnvandConfig.Options;
using Basic5EnvandConfig.Services;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.Configure<MyConfigurationOptionsBuilder>(builder.Configuration.GetSection("OptionBuilder"));

builder.Services.AddHttpClient();
builder.Services.AddTransient<IMyhttpServices,MyhttpServices>();

builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddJsonFile("myconfigFile.json", optional: true, reloadOnChange: true);
});

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

if (app.Environment.IsDevelopment())
{ 
    app.UseDeveloperExceptionPage();  
};





app.UseEndpoints(endpoint => {
    endpoint.Map("/config", async context=>{ 
        await context.Response.WriteAsync("Using Key " + app.Configuration["MyKey"] + "\n");
        await context.Response.WriteAsync("Using Get Value " + app.Configuration.GetValue<string>("MyKey") + "\n");
        await context.Response.WriteAsync("Take defult in not provide as ten " + app.Configuration.GetValue<int>("x", 10) + "\n");
    });


    endpoint.Map("/env", async context => {

        if (app.Environment.IsDevelopment())
        {
            await context.Response.WriteAsync("Welcome to Dev" + "\n");
        };

        if (app.Environment.IsEnvironment("Production"))
        {
            await context.Response.WriteAsync("Welcome to Production" + "\n");
        }


    });



});
app.Run();
