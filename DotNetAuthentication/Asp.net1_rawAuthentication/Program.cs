using Asp.net1_rawAuthentication.Controllers;
using Microsoft.AspNetCore.DataProtection;
using System.Runtime.Intrinsics.Arm;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDataProtection();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<AuthService>();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.Use((ctx, next) =>
{
    var idp= ctx.RequestServices.GetRequiredService<IDataProtectionProvider>();

    var protector = idp.CreateProtector("auth-cookie");
    var mycookie = ctx.Request.Headers.Cookie.FirstOrDefault(x => x.StartsWith("auth="));
    if(mycookie!=null)
    {
        try
        {
            var payloadp = mycookie.Split("=").Last();
            var payload = protector.Unprotect(payloadp);

            var key = payload.Split(":").First();
            var value = payload.Split(":").Last();

            var claims = new List<Claim>();
            claims.Add(new Claim(key, value));
            var identity = new ClaimsIdentity(claims);


            ctx.User = new System.Security.Claims.ClaimsPrincipal(identity);
        }
        catch { }
    }
    

    return next();
});

//app.UseAuthorization();

app.MapControllers();

app.Run();
