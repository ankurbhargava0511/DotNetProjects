var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
//builder.Services.AddControllers().AddXmlSerializerFormatters();
var app = builder.Build();
// This will take care to include use routing + map controller
app.MapControllers();
app.Run();
